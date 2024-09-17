using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class NotifactionManager : MonoBehaviour
{
    [SerializeField] AndroidNotificationControl androidNotifications;
    [SerializeField] IOSNotificationControl iosNotifications;

    // Start is called before the first frame update
    private void Start()
    {
        #if UNITY_ANDROID
        androidNotifications.RequestAuthorization();
        androidNotifications.RegisterNotificationChannel();
        #endif

        #if UNITY_IOS
        StartCoroutine(iosNotifications.RequestAuthorization());
        #endif
    }
    private void OnApplicationFocus(bool focus)
    {
       if(focus == false)
        {
            #if UNITY_ANDROID
            AndroidNotificationCenter.CancelAllNotifications();
            androidNotifications.SendNotification("Alarm Timer", "The alarm that you have scheduled has passed!", 1);
#endif

            #if UNITY_IOS
            iOSNotificationCenter.RemoveAllScheduledNotifications();
            iosNotifications.SendNotification("Alarm Timer", "The alarm that you have scheduled has passed!", "Come back to set another alarm", 1);
            #endif
        }
    }

}
