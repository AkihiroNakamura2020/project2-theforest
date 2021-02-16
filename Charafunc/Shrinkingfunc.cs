using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinkingfunc : MonoBehaviour
{

    public void OnStretch()
    {
        StartCoroutine("StretchEffect");

    }

    public void OnShrink()
    {
        StartCoroutine("ShrinkEffect");

    }

    IEnumerator ShrinkEffect()
    {
        // 繰り返し回数
        int loopcount = 10;

        // 更新間隔
        float waitsecond = 0.5f;

        // スケール設定
        // オフセット値
        float offsetScale = 1.0f / loopcount;
        // 更新値
        float updateScale = 1;

        // オブジェクトの有効化
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        for (int loop = 1; loop < loopcount; loop++)
        {
            // スケール更新
            updateScale = updateScale - offsetScale;
            transform.localScale = new Vector3(updateScale, updateScale, updateScale);
            yield return new WaitForSeconds(waitsecond);

            if (loop == 9)
            {
                OnStretch();
            }

        }
        // 最終スケール
        transform.localScale = new Vector3(offsetScale, offsetScale, offsetScale);

    }

    IEnumerator StretchEffect()
    {
        // 繰り返し回数
        int loopcount = 10;

        // 更新間隔
        float waitsecond = 0.5f;

        // スケール設定
        // オフセット値
        float offsetScale = 1.0f / loopcount;
        // 更新値
        float updateScale = 0;

        // オブジェクトの有効化
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        for (int loop = 0; loop < loopcount; loop++)
        {
            // スケール更新
            updateScale = updateScale + offsetScale;
            transform.localScale = new Vector3(updateScale, updateScale, updateScale);
            yield return new WaitForSeconds(waitsecond);
        }
        // 最終スケール
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

}
