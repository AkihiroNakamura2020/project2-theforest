using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayerManager : MonoBehaviour
{
    //頭上のUIのPrefab
    public GameObject PlayerUiPrefab;
    
    //Localのプレイヤーを設定
    public static GameObject LocalPlayerInstance;
    //頭上UIオブジェクト
    GameObject _uiGo;

   
    void Awake()
    {
                PlayerManager.LocalPlayerInstance = this.gameObject;
    }
    
    void Start()
    {
            _uiGo = Instantiate(PlayerUiPrefab) as GameObject;
        //_uiGo.GetComponent<PlayerUIScript>().UIParent();

        Debug.Log(_uiGo.transform.position);
        Debug.Log("a");
    }
  
}