using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class DateGetter : MonoBehaviour
{
    public TextMeshPro currentDate;
    public TextMeshPro currentTime;

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
