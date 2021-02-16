using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkoncollision : MonoBehaviour
{
    [SerializeField]
    UIeffectdarker uieffectdarker;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //uieffectdarker.UIDarkOn();
        }
    }
}
