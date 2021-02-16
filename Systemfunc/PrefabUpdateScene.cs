using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabUpdateScene : MonoBehaviour
{
    public GameObject originObject; //prefab

    private void Start()
    {
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 2f));
  
        GameObject Prefab = Instantiate(originObject, v, Quaternion.identity);
      
    }
}
