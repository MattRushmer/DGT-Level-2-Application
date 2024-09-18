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
        //this calls the two fuctions from my AndroidNotifications script
        #if UNITY_ANDROID
        androidNotifications.RequestAuthorization();
        androidNotifications.RegisterNotificationChannel();
        #endif

        //this calls the fuction from my IOSNotifications script
        #if UNITY_IOS
        StartCoroutine(iosNotifications.RequestAuthorization());
        #endif
    }
    private void OnApplicationFocus(bool focus)
    {
        // this checks if the application is currently open and if it isnt it will send the notification
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
