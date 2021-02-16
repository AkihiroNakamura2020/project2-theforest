using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 3;  //体力

    [SerializeField]
    public float hp;

    //　HP表示用UI
    [SerializeField]
    private GameObject HPUI;

    //　HP表示用スライダー
    private Slider hpSlider;

    LoadingScript loadingScript;

    GameObject[] playerobjs;

    HPScript playerhp;

    void Start()
    {
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;

        //loadingScript = GameObject.FindWithTag("Loading").GetComponent<LoadingScript>();

    }

    void Update()
    {
        hpSlider.value = hp / maxHp;

        if (hp <= 0)
        {
            //　HP表示用UIを非表示にする
            HideStatusUI();
        }

    }
    //HPUIを非表示にする
    public void HideStatusUI()
    {
        HPUI.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Debug.Log("hit Player");

            Debug.Log("hit Damage");
            hp -= other.gameObject.GetComponent<rodManager>().powerEnemy;

            //hp -= other.gameObject.GetComponent<rodManager>().powerEnemy;
        }

        //体力が0以下になった時{}内の処理が行われる
        if (hp <= 0)
        {
            Destroy(gameObject);  //ゲームオブジェクトが破壊される
        }
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit Enemy");

            Debug.Log("hit Damage");
            hp -= 1;

        }
        //体力が0以下になった時{}内の処理が行われる
        if (hp <= 0)
        {
            Destroy(gameObject);  //ゲームオブジェクトが破壊される
            //loadingScript.NextScene();
        }
    }
    */

    public void powerRecover()
    {
        hp += 1;
    }

    public void powerRecoverall()
    {
        hp += 3;
    }

    public void Damageallplayer()
    {
        playerobjs = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obs in playerobjs)
        {
            playerhp = obs.GetComponent<HPScript>();
            playerhp.hp -= 1;
        }
    }
}
