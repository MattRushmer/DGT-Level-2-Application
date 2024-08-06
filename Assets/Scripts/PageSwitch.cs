using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageSwitch : MonoBehaviour
{
    public void Page1()
    {
        SceneManager.LoadScene("Page 1");
    }
    public void Page2()
    {
        SceneManager.LoadScene("Page 2");
    }
    public void Page3()
    {
        SceneManager.LoadScene("Page 3");
    }
    public void SettingsPage()
    {
        SceneManager.LoadScene("Settings Page");
    }
}
