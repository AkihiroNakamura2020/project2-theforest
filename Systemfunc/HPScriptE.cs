using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScriptE : MonoBehaviour
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

    void Start()
    {
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
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

    public void GetDamage(float edamage)
    {
        hp -= edamage;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        Debug.Log("other.gameObject");
        /*
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
        */
        
    }

}
