using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class IOSNotificationControl : MonoBehaviour
{
#if UNITY_IOS
    //Request acces to send notifactions
   public IEnumerator RequestAuthorization()
    {
        using var request = new AuthorizationRequest(AuthorizationOption.Alert | AuthorizationOption.Badge, true );
        while(!request.IsFinished)
        {
            yield return null;
        }
    }

    // set up notifaction template

    public void SendNotification(string title, string body, string subtitle, int fireTime)
    {
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(fireTime, 0, 0),
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            Identifier = "alarm_Time",
            Title = title,
            Body = body,
            Subtitle = subtitle,
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Badge),
            CategoryIdentifier = "default_category",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger 
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }
#endif
}
