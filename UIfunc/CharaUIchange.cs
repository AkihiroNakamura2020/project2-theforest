using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaUIchange : MonoBehaviour
{
    [SerializeField]
    GameObject baseui;

    [SerializeField]
    GameObject ui1;

    [SerializeField]
    GameObject ui2;

    [SerializeField]
    private float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;

    [SerializeField]
    GameObject timerText;

    Text timer;

    void Start()
    {
        seconds = 0f;
        oldSeconds = 0f;
        timer = timerText.GetComponent<Text>();
    }

    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 10f)
        {
            OpenUi1();
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timer.text = (10-seconds).ToString("f0");
        }
        oldSeconds = seconds;
    }

    public void OpenUi1()
    {
        ui1.SetActive(true);
        StartCoroutine("thisHide");
    }

    public void OpenUi2()
    {
        ui2.SetActive(true);
        StartCoroutine("thisHide");
    }

    IEnumerator thisHide()
    {
        yield return new WaitForSeconds(1);
        baseui.SetActive(false);
    }
}
