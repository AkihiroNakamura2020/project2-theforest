using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogManager : MonoBehaviour
{
    [SerializeField]
    GameObject fogObject;

    public void Fogon()
    {
        fogObject.SetActive(true);
    }

}
