using UnityEngine;

public class FocusControl : MonoBehaviour
{
    string _text1 = "Username";
    string _text2 = "Password";

    readonly Rect _rect1 = new Rect(100, 100, 120, 80);
    readonly Rect _rect2 = new Rect(100, 240, 120, 80);

    void OnGUI()
    {
        GUI.SetNextControlName("tf1");
        _text1 = GUI.TextField(_rect1, _text1);


        if (GUI.Button(new Rect(240, 100, 100, 80), "Focus"))
        {
            GUI.FocusControl("tf1"); 
        }

        GUI.SetNextControlName("tf2");
        _text2 = GUI.TextField(_rect2, _text2);


        if (GUI.Button(new Rect(240, 240, 100, 80), "Focus"))
        {
            GUI.FocusControl("tf2"); 
        }
    }
}