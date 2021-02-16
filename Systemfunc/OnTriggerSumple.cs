using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSumple : MonoBehaviour
{
    private float time;
    bool isTouched = false;

    GameObject Other;

    public Item item;

    void Update()
    {
        if (isTouched)
        {
            time += Time.deltaTime;

            //Debug.Log(time);
            if(time > 3f)
            {
                ChangeBlue();
            }
        }
        else
        {
            time = 0;
            StayRed();
        }    
    }

    //OnTriggerStay関数

    void OnTriggerStay(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            isTouched = true;
            Other = other.gameObject;

            //InventoryTest inventorytest = other.gameObject.GetComponentInChildren<InventoryTest>();

            //オブジェクトの色を赤に変更する
            //GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    //OnTriggerExit関数

    void OnTriggerExit(Collider other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            isTouched = false;
        }
    }

    void ChangeBlue()
    {
        GetComponent<Renderer>().material.color = Color.blue;

        Debug.Log("Other"+Other);
        InventoryTest inventorytest = Other.GetComponentInChildren<InventoryTest>();

        inventorytest.Add(item);
    }

    void StayRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

}