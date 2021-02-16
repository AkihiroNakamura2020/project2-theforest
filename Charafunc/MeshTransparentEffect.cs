using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTransparentEffect : MonoBehaviour
{ 
    Color color;

    void Start()
    {
        color = GetComponent<SkinnedMeshRenderer>().material.color;
    }


    public void OnTransparent()
    {
        StartCoroutine("TransparentEffectOn");
    }

    IEnumerator TransparentEffectOn()
    {
        // 繰り返し回数
        int loopcount = 10;

        float waitsecond = 0.5f;

        float offsetcolor = 1.0f / loopcount;
        // 更新値
        float updatecolor = 1;

        // オブジェクトの有効化
        color.a = 1;

        for (int loop = 1; loop < loopcount; loop++)
        {
            // スケール更新
            updatecolor = updatecolor - offsetcolor;
            color.a = updatecolor;
            GetComponent<SkinnedMeshRenderer>().material.color = color;

            yield return new WaitForSeconds(waitsecond);
        }
        // 最終
        yield return new WaitForSeconds(1);
        color.a = 1;
        GetComponent<SkinnedMeshRenderer>().material.color = color;
    }
}