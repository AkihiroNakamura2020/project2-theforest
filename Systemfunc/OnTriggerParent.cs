using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerParent : MonoBehaviour
{

    bool flag = false;
    Animator anim;
    
    [SerializeField] private Collider m_Collider;


    private void Update()
    {
        if (flag)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim = GetComponent<Animator>();
                anim.SetTrigger("Triggerrodc");

            }

        }
        Debug.Log(flag);
    }

    public void HitStart()
    {
        m_Collider.enabled = true;
    }

    public void HitEnd()
    {
        m_Collider.enabled = false;
    }

    public void FlagOn()
    {
        flag = true;
    }


    void OnTriggerStay(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {

            this.transform.parent = other.transform;

            Transform myTransform = this.transform;

            // 座標を取得
            transform.localPosition = new Vector3(0.7f, 0.3f, 0.3f);

            /*
            Vector3 pos = myTransform.position;
            pos.x = 0.7f;    // x座標へ加算
            pos.y = 1.5f;    // y座標へ加算
            pos.z = -3.3f;    // z座標へ加算
            myTransform.position = pos;  // 座標を設定
            
             */

            Debug.Log(myTransform.position);

            flag = true;
            m_Collider.enabled = false;
        }
    }

}