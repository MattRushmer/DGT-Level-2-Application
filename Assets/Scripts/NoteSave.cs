using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteSave : MonoBehaviour
{
    public TMP_InputField inputField;
    public string ourText;
    // Start is called before the first frame update
    // this loads the contents of my notes on open
    void Start()
    {
        ourText = PlayerPrefs.GetString("NoteContents");
        inputField.text = ourText;
    }

    
    //this is my fuction which saves my notes
    void Update()
    {
        ourText = inputField.text;
        PlayerPrefs.SetString("NoteContents", ourText);
    }
    
    
}