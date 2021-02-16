using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabGene : MonoBehaviour
{
    //Canvasをセット
   // public GameObject canvasObject;

    public GameObject playerprefab;

    void Start()
    {
        //GameObjectを生成、生成したオブジェクトを変数に代入
        //GameObject Prefab = (GameObject)Instantiate(playerprefab);
        GameObject Prefab = Instantiate(playerprefab);


        //Prefab.transform.SetParent(canvasObject.transform, false);
        Prefab.transform.SetParent(this.transform, false);

    }

}
