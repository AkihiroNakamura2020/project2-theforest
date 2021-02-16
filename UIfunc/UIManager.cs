using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] GameObject inventory;

    bool flag = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SelectInventory();

            flag = !flag;
        }             
    }

    void SelectInventory()
    {
        if (flag)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);

        }
    }

}