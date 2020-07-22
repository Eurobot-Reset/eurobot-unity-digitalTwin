/*
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
    public class CustomMsgSubscriber : UnitySubscriber<MessageTypes.Std.String>
    {
        public string data;
	    
        public string[] data_arr = {"Start recording"};
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Std.String message)
        {
            data = message.data;
	        Array.Resize(ref data_arr, data_arr.Length + 1);
	        data_arr[data_arr.Length - 1] = data;
            // Debug.Log(data);
            isMessageReceived = true;
        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }
        
        private void ProcessMessage()
        {
            isMessageReceived = false;
        }
    }
}
