using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutohideUI : MonoBehaviour
{
    [SerializeField]
    GameObject gameobject;

    public void Gohide()
    {
        StartCoroutine("canHide");
    }

    IEnumerator canHide()
    {
        yield return new WaitForSeconds(1);
        gameobject.SetActive(false);
    }
}
