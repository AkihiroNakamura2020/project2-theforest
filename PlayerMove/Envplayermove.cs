using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envplayermove : MonoBehaviour
{
    private Vector3 velocity;
    
    //　入力値
    private Vector3 input;
    //　歩く速さ
    [SerializeField]
    private float walkSpeed = 1.5f;
    //　rigidbody
    private Rigidbody rigid;
  

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()//移動の速度計算
    {
            input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            //　方向キーが多少押されている
            if (input.magnitude > 0f)
            {
                transform.LookAt(transform.position + input);

                velocity += transform.forward * walkSpeed;

            } 
    }

    void FixedUpdate()//実際の移動
    {
        //　キャラクターを移動させる処理
        rigid.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

}
