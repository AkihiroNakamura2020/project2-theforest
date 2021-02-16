using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneplayerUI : MonoBehaviour
{
    [SerializeField]
    GameObject droneUI;

    // Start is called before the first frame update
    void Start()
    {
        droneUI.SetActive(true);
    }
}
