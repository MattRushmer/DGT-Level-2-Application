using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class DateGetter : MonoBehaviour
{
    public Text currentDate;
    public Text currentTime;

    [SerializeField] private TMP_InputField hoursInput, minutesInput, secondsInput;
    [SerializeField] private TMP_Dropdown dropDown;

    public GameObject alarmPanel;

    private bool isAlarmSet = false;
    private DateTime alarmtime = DateTime.Today;

    void Start()
    {
        string date = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy");
        currentDate.text = "Todays Date: " + date;
    }

    private void Update()
    {

        int hours = DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;
        int second = DateTime.Now.Second;

        bool isAM = hours < 12;

        currentTime.text = "Current Time: " + $"{hours % 12:D2}:{minute:D2}:{second:D2} {(isAM ? "AM" : "PM")}";

        if(isAlarmSet && DateTime.Now > alarmtime)
        {
            alarmPanel.SetActive(true);
        }

        

    }

    public void SetAlarm()
    {
        alarmtime = DateTime.Today;

        int hours;
        if(dropDown.value == 0)
        {
            hours = int.Parse(hoursInput.text);
        }
        else
        {
            hours = int.Parse(hoursInput.text) + 12;
        }

        TimeSpan ts = TimeSpan.Parse($"{hours}:{minutesInput.text}:{secondsInput.text}");
        alarmtime += ts;

        if(DateTime.Now >= alarmtime)
        {
            alarmtime = alarmtime.AddDays(1);
        }

        isAlarmSet = true;

        
    }


}
