using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class DateGetter : MonoBehaviour
{
    public Text currentDate;
    public Text currentTime;

    void Start()
    {
        string date = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy");
        currentDate.text = "Todays Date: " + date;
    }

    private void Update()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss");
        currentTime.text = "Current Time:" + time;
    }


}
