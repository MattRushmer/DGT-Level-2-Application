using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteSave : MonoBehaviour
{
    public TMP_InputField inputField;
    string ourText;
    // Start is called before the first frame update
    // this loads the contents of my notes on open
    private void Start()
    {
        TMP_InputField inputField1 = inputField;
        inputField1.text = PlayerPrefs.GetString("NoteContents");
    }

    
    //this is my fuction which saves my notes
    public void Save()
    {
        ourText = inputField.text;
        PlayerPrefs.SetString("NoteContents", ourText);
    }
    
    
}