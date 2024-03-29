﻿/*
© CentraleSupelec, 2017
Author: Dr. Jeremy Fix (jeremy.fix@centralesupelec.fr)

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

// Adjustments to new Publication Timing and Execution Framework
// © Siemens AG, 2018, Dr. Martin Bischoff (martin.bischoff@siemens.com)

using UnityEngine;
using System;

namespace RosSharp.RosBridgeClient
{
    public class CustomTwistSubscriber : UnitySubscriber<MessageTypes.Geometry.Twist>
    {
        public Transform SubscribedTransform;

        private float previousRealTime;
        private float flipper;
        public Vector3 linearVelocity;
        public Vector3 angularVelocity;
        private bool isMessageReceived;
        Rigidbody rb;
        public float speedScaleFactor;
        public float torqueScaleFactor;

        protected override void Start()
        {
            rb = GetComponent<Rigidbody>();
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Geometry.Twist message)
        {
            linearVelocity = ToVector3(message.linear).Ros2Unity();
            flipper = linearVelocity.y;
            linearVelocity.y = linearVelocity.z;
            linearVelocity.z = flipper;

            flipper = linearVelocity.y;
            linearVelocity.y = -linearVelocity.x;
            linearVelocity.x = flipper;

            flipper = linearVelocity.y;
            linearVelocity.y = linearVelocity.z;
            linearVelocity.z = flipper;

            linearVelocity *= 10;

            angularVelocity = -ToVector3(message.angular).Ros2Unity();
            // angularVelocity.y = -angularVelocity.y;
            angularVelocity *= 10;
            isMessageReceived = true;
        }

        private static Vector3 ToVector3(MessageTypes.Geometry.Vector3 geometryVector3)
        {
            return new Vector3((float)geometryVector3.x, (float)geometryVector3.y, (float)geometryVector3.z);
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }
        private void ProcessMessage()
        {
            float deltaTime = Time.realtimeSinceStartup - previousRealTime;

            //SubscribedTransform.Translate(linearVelocity * deltaTime);
            //SubscribedTransform.Rotate(Vector3.forward, angularVelocity.x * deltaTime);
            //SubscribedTransform.Rotate(Vector3.up, angularVelocity.y * deltaTime);
            //SubscribedTransform.Rotate(Vector3.left, angularVelocity.z * deltaTime);

            previousRealTime = Time.realtimeSinceStartup;

            Vector3 moveVector = transform.right * linearVelocity.x + transform.forward * linearVelocity.z;

            rb.AddForce(moveVector * speedScaleFactor);
            rb.AddTorque(transform.up * angularVelocity.y * torqueScaleFactor);

            isMessageReceived = false;
            
            float[] speedMsgData = new float[] {linearVelocity.x, linearVelocity.z, angularVelocity.y};
        
            Debug.Log(speedMsgData);
        }
    }
}