using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{

    //public GameObject inventory; //ヒエラルキー上のオブジェクト
  
    public List<Item> items = new List<Item>();

    InventoryTest inventoryTest;
    InventoryUITest inventoryUITest; //InventoryUITestコンポーネント

    void Start()
    {
        InventoryUITest inventoryui = GetComponent<InventoryUITest>(); 
        inventoryui.UpdateUI();
    }

    public void Add(Item item)
    {
        items.Add(item);
        InventoryUITest inventoryui = GetComponent<InventoryUITest>(); 
        inventoryui.UpdateUI();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        InventoryUITest inventoryui = GetComponent<InventoryUITest>(); 
        inventoryui.UpdateUI();

    }
}
