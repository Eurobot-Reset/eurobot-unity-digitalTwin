﻿/*
© Siemens AG, 2018-2019
Author: Berkay Alp Cakal (berkay_alp.cakal.ct@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;
// using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class CustomLaserScanReader : MonoBehaviour
    {
        private Ray[] rays;
        private RaycastHit[] raycastHits;
        private Vector3[] directions;
        private LaserScanVisualizer[] laserScanVisualizers;

        public float systemError = 0.04f;
        public float angle = 180;
	    public float angularResolution = 1;
        public bool hasNoise = true;
        public int samples = 1024;
        public int update_rate = 10000;
        public float angle_min = 0;
        public float angle_max = 6.28f;
        public float angle_increment = 0.0174533f;
        public float time_increment = 0;
        public float scan_time = 0;
        public float range_min = 0.12f;
        public float range_max = 3.5f;
        public bool showDebugRay = true;
        private int numLines;
        private float error;
        public Color color = Color.blue;
        private float previousScanTime = 0;
        private float scanPeriod;
        public float[] ranges;
        public float[] intensities;

        public void Start()
        {
            numLines = (int)(angle / angularResolution) + 1;

            // samples = numLines;
            
            directions = new Vector3[samples];
            ranges = new float[samples];
            intensities = new float[samples];
            rays = new Ray[samples];
            raycastHits = new RaycastHit[samples]; 

            scanPeriod = samples / update_rate;

            range_min *= 100;
            range_max *= 100;

            // InvokeRepeating("UpdateStatus", 0.1f, samples/update_rate);   
        }

        void Update() 
        {
            if (Time.realtimeSinceStartup >= previousScanTime + scanPeriod)
            {
                // Debug.Log("Updating LIDAR data");
                Scan();
                previousScanTime = Time.realtimeSinceStartup;
            
            }
        }

        void UpdateStatus()
        {
            // Scan();
        }

        public float[] Scan()
        {
            MeasureDistance();

            error = (hasNoise ? Noise() : 0.0f);

            laserScanVisualizers = GetComponents<LaserScanVisualizer>();
            if (laserScanVisualizers != null)
                foreach (LaserScanVisualizer laserScanVisualizer in laserScanVisualizers)
                    laserScanVisualizer.SetSensorData(gameObject.transform, directions, ranges, range_min, range_max);

            for (int i = 0; i < samples; i++)
                ranges[i] = ranges[i]/100 + error;
            
            return ranges;
        }

        private void MeasureDistance()
        {
            rays = new Ray[samples];
            raycastHits = new RaycastHit[samples];
            ranges = new float[samples];
            intensities = new float[samples];

            for (int i = 0; i < samples; i++)
            {
                intensities[i] = 1000;

                // rays[i] = new Ray(transform.position, transform.rotation * Quaternion.AngleAxis(angle * 0.5f + (-1 * i * angularResolution), Vector3.up) * Vector3.forward);
                // directions[i] = Quaternion.Euler(-transform.rotation.eulerAngles) * rays[i].direction;
                
                rays[i] = new Ray(transform.position, Quaternion.Euler(new Vector3(0, angle_max - angle_increment * i * 180 / Mathf.PI, 0)) * transform.forward);
                directions[i] = Quaternion.Euler(-transform.rotation.eulerAngles) * rays[i].direction;

                ranges[i] = range_max;
                
                raycastHits[i] = new RaycastHit();
                if (Physics.Raycast(rays[i], out raycastHits[i], range_max))
                    if (raycastHits[i].distance >= range_min && raycastHits[i].distance <= range_max)
                        ranges[i] = raycastHits[i].distance;
                
                if (showDebugRay)
                    Debug.DrawRay(rays[i].origin, rays[i].direction * ranges[i], color);
            }

        }

        float Noise() 
        {
		    return Random.Range(-systemError, systemError);
	    }
    }
}