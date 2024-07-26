using System;
using System.Collections;
using UnityEngine;

namespace com.homemade.utils.internet
{
    public class EzInternetComponent : MonoBehaviour
    {
        private float timeCheck = 5f;
        private bool isLog = true;

        private Coroutine internetCoroutine;

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

        public Action OnDisConnect;
        public Action On_4G_Connect;
        public Action OnWifiConnect;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void StartCheckInternet()
        {
            internetCoroutine = StartCoroutine(CheckInternetConnectionCoroutine());
        }

        public void StopCheckInternet()
        {
            if(internetCoroutine != null)
            {
                StopCoroutine(internetCoroutine);

                Destroy(gameObject);
            }
        }

        private IEnumerator CheckInternetConnectionCoroutine()
        {
            while (true)
            {
                CheckInternetConnection();
                // Wait for X seconds before checking again
                yield return new WaitForSeconds(timeCheck);
            }
        }

        private void CheckInternetConnection()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Log("No internet connection.");

                OnDisConnect?.Invoke();
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                Log("Internet is reachable via carrier data network.");

                On_4G_Connect?.Invoke();
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                Log("Internet is reachable via Wi-Fi or Ethernet.");

                OnWifiConnect?.Invoke();
            }
        }

        private void Log(string message)
        {
            if (isLog)
            {
                Debug.Log(message);
            }
        }
    }
}

/*
- NetworkReachability.ReachableViaCarrierDataNetwork
    + Type of Network: This indicates that the device is connected to the internet via a mobile carrier's data network (e.g., 3G, 4G, LTE).
    + Speed and Latency: Generally, mobile data networks may have higher latency and variable speeds compared to Wi-Fi. The performance can vary based on signal strength, network congestion, and the specific technology (e.g., 3G vs. 4G).
    + Data Costs: Mobile data often comes with usage limits or costs, so it might be more expensive to use compared to Wi-Fi.
    + Mobility: Provides internet access on the go, allowing connectivity while moving.

- NetworkReachability.ReachableViaLocalAreaNetwork
    + Type of Network: This indicates that the device is connected to the internet via a local area network, such as Wi-Fi or Ethernet.
    + Speed and Latency: Typically, local area networks provide lower latency and higher, more stable speeds compared to mobile data networks. The performance is usually better for activities like streaming, gaming, and downloading large files.
    + Data Costs: Wi-Fi is often provided with a flat-rate cost or included as part of an internet service plan, making it generally more cost-effective for heavy data usage.
    + Mobility: Limited to the range of the Wi-Fi network or the physical location of the Ethernet connection, meaning it's not suitable for use while moving around outside the coverage area.
 */
