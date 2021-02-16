using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerUIScript : MonoBehaviour
{
    //キャラの頭上に乗るように調整するためのOffset
    //public Vector3 ScreenOffset = new Vector3(0f, 20f, 0f);
    //public Text PlayerNameText;
    
    //float _characterControllerHeight;
    Transform _targetTransform;
    Vector3 _targetPosition;
    

    void Start()
    {
        GameObject target = GameObject.FindWithTag("Player");//他のPlayerもいるので微妙

        if(target != null)
        {
            _targetTransform = target.GetComponent<Transform>();

        }
    }

    void LateUpdate()
    {
        //targetのオブジェクトを追跡する
        if (_targetTransform != null)
        {
            _targetPosition = _targetTransform.position;    //三次元空間上のtargetの座標を得る
                                                            //this.transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + ScreenOffset;
            this.transform.position = _targetPosition;
        }
        else
        {
            //nullだったら見つけてくる
            GameObject target = GameObject.FindWithTag("Player");//他のPlayerもいるので微妙
            _targetTransform = target.GetComponent<Transform>();
            _targetPosition = _targetTransform.position;    //三次元空間上のtargetの座標を得る
                                                            //this.transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + ScreenOffset;
            this.transform.position = _targetPosition;
        }
        
    }
}