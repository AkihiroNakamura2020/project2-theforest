using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    //InputFieldを格納するための変数
    [SerializeField]
    InputField inputField;

    [SerializeField]
    private Text roomname;

    // テキストを格納する変数
    [SerializeField]
    private Text textbox;


    // Start is called before the first frame update
    void Start()
    {
        // InputFieldコンポーネントを取得
        // inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }


    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputName()
    {
        // string value = roomname.text;
        textbox.text = inputField.text;

        // Debug.Log(value);
        /*
        if (value.IndexOf("\n") != -1)　//認識されない
        {
            Debug.Log("textbox");

            // テキストに入力内容を表示
            textbox.GetComponent<Text>().text = value;

            //入力フォームのテキストを空にする
            //inputField.text = "";

            // 入力できないようにする
            inputField.interactable = false;
        }
        */
    }

    public void OnSubmit()
    {
        Debug.Log("決定");
        //sampleText.text = inputField.text;
        //textbox.text = inputField.text;

        // 入力できないようにする
        inputField.interactable = false;

        //inputField.text = "";

    }
}