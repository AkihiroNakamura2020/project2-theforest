using System.Collections;
using System.Collections.Generic;// Listを扱うのに必要
using UnityEngine;

public class ListScript : MonoBehaviour
{
    public GameObject ListObject;// リストに入れるために生成するプレファブ
    public List<GameObject> ObjectList = new List<GameObject>();// プレイファブを入れるリスト
    private int ObjectCount;// 生成したプレファブの数

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// もし、右クリックしたら、
        {
            GameObject ListObjects = GameObject.Instantiate(ListObject) as GameObject;// ListObjectsとしてプレファブを生成する
            ListObjects.transform.position = transform.position;// このオブジェクトの位置にプレファブの座標を移動させる
            ListObjects.transform.rotation = Quaternion.identity;// プレファブの向きを元のままにする
            ObjectList.Add(ListObjects);// リストにプレファブを加える
            ObjectCount += 1;// プレファブの数を1増やす
        }

        if (ObjectCount < 1)// もしプレファブの数が1以下なら、
        {
            ObjectCount = 0;// プレファブの数を0にする
        }

        if (Input.GetMouseButtonDown(1))// もし、右クリックしたら、
        {
            Destroy(ObjectList[ObjectCount - 1]);// リストの(プレファブの数-1)番目のオブジェクトを消す
            ObjectList.RemoveAt(ObjectCount - 1);// リストの(プレファブの数-1)番目を削除する
            ObjectCount -= 1;// プレファブの数を1減らす
        }
    }
}