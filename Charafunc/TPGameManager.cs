using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPGameManager : MonoBehaviour
{
    private float time;


    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
            // transformを取得
            Transform myTransform = this.transform;

            // 座標を取得
            Vector3 pos = myTransform.position;
            pos.x = Random.Range(-2f, 2f);    // x座標
            pos.y = 3f;    // y座標
            pos.z = 0f;    // z座標

            myTransform.position = pos;  // 座標を設定

            //Instantiate(this.gameObject, new Vector3(-40, vecY, 30), Quaternion.identity);
            time = 1.0f;
        }
    }
}