using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClearText : MonoBehaviour
{
    InputField inputField;

    private void Start()
    {
        inputField = GetComponent<InputField>();
    }

    public void OnClear()
    {
        inputField.text = "";
        //this.text = "";

        //GUI.FocusControl("");
    }
}
