using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class AndroidNotificationControl : MonoBehaviour
{
#if UNITY_ANDROID
    //Request authorization to send notrifaction

    public void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    // Register a notifaction channe;

    public void RegisterNotificationChannel()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Alarm Timer"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    //set up notification template

    public void SendNotification(string title, string text, int fireTime)
    {
        //this sets up what the notification will look like
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = System.DateTime.Now.AddHours(fireTime);
        notification.SmallIcon = "Logo";
        notification.LargeIcon = "Logo";

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
#endif
}
