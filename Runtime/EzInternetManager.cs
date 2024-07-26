using UnityEngine;
using UnityEngine.Events;

namespace com.homemade.utils.internet
{
    public class EzInternetManager : MonoBehaviour
    {
        [Header("Value")]
        [Space(5)]
        [SerializeField] private float timeCheck = 5f;
        [SerializeField] private bool isLog = true;

        [Header("Action")]
        [Space(10)]
        [SerializeField] private UnityEvent OnDisConnect;

        [Space(10)]
        [Tooltip("Call on mobile device")] 
        [SerializeField] private UnityEvent On_4G_Connect;

        [Space(10)]
        [SerializeField] private UnityEvent OnWifiConnect;

        private EzInternet internet;

        private void Start()
        {
            internet = new EzInternet();
            
            // Add value
            internet.TimeCheck = timeCheck;
            internet.IsLog = isLog;

            // Add event
            internet.OnDisConnect += () => OnDisConnect?.Invoke();
            internet.On_4G_Connect += () => On_4G_Connect?.Invoke();
            internet.OnWifiConnect += () => OnWifiConnect?.Invoke();

            internet.Start();
        }

        private void OnDestroy()
        {
            internet?.Stop();
        }
    }
}
