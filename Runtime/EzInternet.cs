using System;
using UnityEngine;

namespace com.homemade.utils.internet
{
    public class EzInternet
    {
        private float timeCheck = 5f;
        private bool isLog = true;

        // Get & Set
        public float TimeCheck 
        { 
            get => timeCheck;
            set => timeCheck = value;
        }

        public bool IsLog
        {
            get => isLog;
            set => isLog = value;
        }

        public event Action OnDisConnect;
        public event Action On_4G_Connect;
        public event Action OnWifiConnect;

        private EzInternetComponent component;

        public EzInternet() { }

        public EzInternet(float timeCheck, bool isLog = true)
        {
            this.timeCheck = timeCheck;
            this.isLog = isLog;
        }

        public void Start()
        {
            // Create object
            GameObject obj = new GameObject("Internet Check");
            component = obj.AddComponent<EzInternetComponent>();

            // Add value and action
            component.TimeCheck = timeCheck;
            component.IsLog = isLog;
            component.OnDisConnect = OnDisConnect;
            component.On_4G_Connect = On_4G_Connect;
            component.OnWifiConnect = OnWifiConnect;

            // Start internet check
            component.StartCheckInternet();
        }

        public void Stop()
        {
            component.StopCheckInternet();
            component = null;

            OnDisConnect = null;
            On_4G_Connect = null;
            OnWifiConnect = null;
        }
    }
}
