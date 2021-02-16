using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    public GameObject canvas;//キャンバス

    public GameObject ParentPrefab;

    string test = "testだよ";

    void Start()
    {
      
        GameObject prefab = Instantiate(ParentPrefab, this.transform.position, Quaternion.identity);
        prefab.transform.SetParent(canvas.transform, false);

        prefab.transform.Find("Image/Text").GetComponent<Text>().text = test;

    }

    void Update() { }
}