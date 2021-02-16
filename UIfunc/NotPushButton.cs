using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPushButton : MonoBehaviour
{
    [SerializeField]
    GameObject droneUI;

    CanvasGroup canvasgroup;

    void Start()
    {
        canvasgroup = droneUI.GetComponent<CanvasGroup>();
    }

    public void CanvasLock()
    {
        StartCoroutine("canInt");
    }

    IEnumerator canInt()
    {
        canvasgroup.interactable = false;
      
        yield return new WaitForSeconds(3);
        canvasgroup.interactable = true;
    }
}
