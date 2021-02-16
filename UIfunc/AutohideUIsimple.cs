using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutohideUIsimple : MonoBehaviour
{
    [SerializeField]
    GameObject gameobject;

    void Start()
    {
        StartCoroutine("Hide");
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(3);
        gameobject.SetActive(false);
    }
}
