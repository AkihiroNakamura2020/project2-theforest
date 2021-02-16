using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaUIchange2 : MonoBehaviour
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

    [SerializeField]
    photonCount photoncount;

    GameObject childobject;

    Text timer;

    bool flag =false;

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
            
            if (!flag)
            {
                OpenUi1();
                photoncount.BeforeCount();
            }

        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timer.text = (10 - seconds).ToString("f0");
        }
        oldSeconds = seconds;
    }

    public void OpenUi1()
    {
        StartCoroutine("thisHide");
        flag = true;
    }

    public void OpenUi2()
    {
        StartCoroutine("thisHide2");
        flag = true;
    }

    IEnumerator thisHide()
    {
        yield return new WaitForSeconds(2);
        ui1.SetActive(true);

        yield return new WaitForSeconds(1);
        baseui.SetActive(false);
    }

    IEnumerator thisHide2()
    {
        yield return new WaitForSeconds(2);
        ui2.SetActive(true);

        yield return new WaitForSeconds(1);
        baseui.SetActive(false);
    }

    public void Humanoff()
    {
        childobject = GameObject.FindWithTag("human");
        childobject.SetActive(false);
    }

    public void Wollfoff()
    {
        childobject = GameObject.FindWithTag("wolf");
        childobject.SetActive(false);
    }
}
