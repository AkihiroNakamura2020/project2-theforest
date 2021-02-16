using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUITest : MonoBehaviour
{
    public Transform slotsParent;

    InventoryTest inventoryTest;
    InventoryUITest inventoryUITest; //InventoryUITestコンポーネント

    Slot[] slots;
    
    void Awake()
    {
        slots = slotsParent.GetComponentsInChildren<Slot>();
       // InventoryTest inventoryTest = GetComponent<InventoryTest>();
        //GameObject instance = GetComponent<Inventory>();
    }

    public void UpdateUI()
    {
        InventoryTest inventoryTest = GetComponent<InventoryTest>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryTest.items.Count)//UIで表示される前のインベントリの中身Inventory.instance.items
            {
                slots[i].AddItem(inventoryTest.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        Debug.Log("UpdateUI");
    }
    
}
