using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    public void Layerchange()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Stealth");
        StartCoroutine("BackLayer");
    }

    private IEnumerator BackLayer()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.layer = LayerMask.NameToLayer("MiniMap");
    }
}
