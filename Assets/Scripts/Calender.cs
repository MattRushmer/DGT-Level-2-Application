using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    /// <summary>
    /// Cell or slot in the calendar. All the information each day should now about itself
    /// </summary>
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        /// <summary>
        /// Constructor of Day
        /// </summary>
        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        /// <summary>
        /// Call this when updating the color so that both the dayColor is updated, as well as the visual color on the screen
        /// </summary>
        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;
        }

        /// <summary>
        /// When updating the day we decide whether we should show the dayNum based on the color of the day
        /// This means the color should always be updated before the day is updated
        /// </summary>
        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == Color.green)
            {
                obj.GetComponentInChildren<Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    /// <summary>
    /// All the days in the month. After we make our first calendar we store these days in this list so we do not have to recreate them every time.
    /// </summary>
    private List<Day> days = new List<Day>();

    /// <summary>
    /// Setup in editor since there will always be six weeks. 
    /// Try to figure out why it must be six weeks even though at most there are only 31 days in a month
    /// </summary>
    public Transform[] weeks;

    /// <summary>
    /// This is the text object that displays the current month and year
    /// </summary>
    public Text MonthAndYear;

    /// <summary>
    /// this currDate is the date our Calendar is currently on. The year and month are based on the calendar, 
    /// while the day itself is almost always just 1
    /// If you have some option to select a day in the calendar, you would want the change this objects day value to the last selected day
    /// </summary>
    public DateTime currDate = DateTime.Now;

    /// <summary>
    /// In start we set the Calendar to the current date
    /// </summary>
    private void Start()
    {
        UpdateCalendar(DateTime.Now.Year, DateTime.Now.Month);
    }

    /// <summary>
    /// Anytime the Calendar is changed we call this to make sure we have the right days for the right month/year
    /// </summary>
    void UpdateCalendar(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        currDate = temp;
        MonthAndYear.text = temp.ToString("MMMM") + " " + temp.Year.ToString();
        int startDay = GetMonthStartDay(year, month);
        int endDay = GetTotalNumberOfDays(year, month);


        ///Create the days
        ///This only happens for our first Update Calendar when we have no Day objects therefore we must create them

        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }
        ///loop through days
        ///Since we already have the days objects, we can just update them rather than creating new ones
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay >= endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                days[i].UpdateDay(i - startDay);
            }
        }

        ///This just checks if today is on our calendar. If so, we highlight it in green
        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(Color.green);
        }

    }

    /// <summary>
    /// This returns which day of the week the month is starting on
    /// </summary>
    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);

        //DayOfWeek Sunday == 0, Saturday == 6 etc.
        return (int)temp.DayOfWeek;
    }

    /// <summary>
    /// Gets the number of days in the given month.
    /// </summary>
    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    /// <summary>
    /// This either adds or subtracts one month from our currDate.
    /// The arrows will use this function to switch to past or future months
    /// </summary>
    public void SwitchMonth(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalendar(currDate.Year, currDate.Month);
    }
}