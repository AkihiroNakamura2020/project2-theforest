using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    InventoryTest inventorytest;
    Slot[] slots;
    public Transform slotsParent;
    ChangeColoricon changeColoricon;

    void Start()
    {
        inventorytest = GetComponent<InventoryTest>();
        slots = slotsParent.GetComponentsInChildren<Slot>();

        Invoke("Item1", 3);
        Invoke("Item2", 4);
        Invoke("Item3", 5);
    }

    void Item1()
    {
        int index = Random.Range(0, inventorytest.items.Count); //int型なので最大値を含まない
        Item item1 = inventorytest.items[index];
        Debug.Log("index:" + index);

        Debug.Log(inventorytest.items.Count);
        Debug.Log("3秒後に実行されたitem1" + item1);
        //inventorytest.items.RemoveAt(index);
        //inventorytest.Remove(item1);

        SlotManage(index);

        //Button button = slots[index].GetComponentInChildren<Button>();
        //button.interactable = true;

    }

    void Item2()
    {
        int index = Random.Range(0, inventorytest.items.Count);
        Item item2 = inventorytest.items[index];
        Debug.Log("index:" + index);

        Debug.Log("4秒後に実行されたitem2" + item2);
        //inventorytest.items.RemoveAt(index);
        //inventorytest.Remove(item2);

        SlotManage(index);

        //Button button = slots[index].GetComponent<Button>();
        //Button button = slots[index].GetComponentInChildren<Button>();
        //button.interactable = true;

    }

    void Item3()
    {
        //int index = Random.Range(0, inventorytest.items.Count);
        int index = 0;
        Item item3 = inventorytest.items[index];
        Debug.Log("index:" + index);

        Debug.Log("5秒後に実行されたitem3" + item3);
        //inventorytest.items.RemoveAt(index);
        //inventorytest.Remove(item3);

        SlotManage(index);

        //Button button = slots[index].GetComponent<Button>();
        //Button button = slots[index].GetComponentInChildren<Button>();
        //Button button = slots[index].GetComponentInChildren<Button>();
        //button.interactable = true;

                /*
        Debug.Log("i1:" + inventorytest.items[0].name);
        Debug.Log("i2:" + inventorytest.items[1].name);
        Debug.Log("i3:" + inventorytest.items[2].name);
        Debug.Log("index:" + index);
        */


    }

    void SlotManage(int index)
    {
        Debug.Log("SlotManage");
        Debug.Log(inventorytest.items[index].name);

        if (inventorytest.items[index].name == "DIY")
        {
            Button button = slots[0].GetComponentInChildren<Button>();
            button.interactable = true;

            changeColoricon = slots[0].GetComponentInChildren<ChangeColoricon>();
            Debug.Log("changeColoricon"+changeColoricon);
            changeColoricon.BackColor();

            inventorytest.items.RemoveAt(index);
            return;
        }

        if (inventorytest.items[index].name == "Melon")
        {
            Button button = slots[1].GetComponentInChildren<Button>();
            button.interactable = true;

            changeColoricon = slots[1].GetComponentInChildren<ChangeColoricon>();
            Debug.Log("changeColoricon" + changeColoricon);
            changeColoricon.BackColor();

            inventorytest.items.RemoveAt(index);
            return;
        }

        if (inventorytest.items[index].name == "Sea")
        {
            Button button = slots[2].GetComponentInChildren<Button>();
            button.interactable = true;

            changeColoricon = slots[2].GetComponentInChildren<ChangeColoricon>();
            Debug.Log("changeColoricon" + changeColoricon);
            changeColoricon.BackColor();

            inventorytest.items.RemoveAt(index);
            return;
        }

    }

    /*
    List<string> numbers = new List<string>();
    
    void Start()
    {
        numbers.Add("ichigo");
        numbers.Add("ringo");
        numbers.Add("mikan");

        Invoke("Item1", 3);
        Invoke("Item2", 4);
        Invoke("Item3", 5);
    }

    void Item1()
    {
        int index = Random.Range(0, numbers.Count); //int型なので最大値を含まない
        string item1 = numbers[index];

        Debug.Log(numbers.Count);
        Debug.Log("3秒後に実行されたitem1"+item1);
        numbers.RemoveAt(index);
    }

    void Item2()
    {
        int index = Random.Range(0, numbers.Count);
        string item2 = numbers[index];

        Debug.Log("4秒後に実行されたitem2" + item2);
        numbers.RemoveAt(index);
    }

    void Item3()
    {
        int index = Random.Range(0, numbers.Count);
        string item3 = numbers[index];

        Debug.Log("5秒後に実行されたitem3" + item3);
        numbers.RemoveAt(index);
    }
    */

}