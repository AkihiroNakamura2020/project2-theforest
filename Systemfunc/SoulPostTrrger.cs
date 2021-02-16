using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPostTrrger : MonoBehaviour
{
    private float _targetTime=3;
    private float _time = 0;

    [SerializeField]
    GameObject GolemsoulPost;

    bool stayflag=false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //_time += Time.fixedDeltaTime;//物理演算の処理内では固定フレームなので Time.deltaTimeはいまいちとのこと
            _time += Time.deltaTime;//違和感は特に感じなかったのでTime.deltaTimeへ
            if (_time >= _targetTime)
            {
                if (!stayflag)
                {
                    OpenSoulPost();
                }
                _time = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stayflag = false;
        }
    }


    void OpenSoulPost()
    {
        GolemsoulPost.SetActive(true);
        stayflag = true;
    }

    public void CloseSoulPost()
    {
        GolemsoulPost.SetActive(false);
    }
}
