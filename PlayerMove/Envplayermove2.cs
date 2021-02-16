using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envplayermove2 : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    float mixvalue;
    float Lmixvalue;

    Rigidbody rb;

    float moveSpeed = 1f;
    Vector3 lastmov_f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastmov_f = transform.position;
        Lmixvalue = 0;

        lastmov_f = transform.position;

    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        mixvalue = inputHorizontal + inputVertical;

        if(Lmixvalue != mixvalue)
        {
            MoveGo();
            Lmixvalue = mixvalue;
            Debug.Log("aaa");
        }

    }
   
    void MoveGo()
    {
        Vector3 cameraForward = transform.position;
        cameraForward.y = 0;

        lastmov_f.y = 0;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        //Vector3 moveForward = cameraForward.normalized * inputVertical + Camera.main.transform.right * inputHorizontal;
        Vector3 moveForward = cameraForward - lastmov_f + new Vector3(inputHorizontal*10, 0, inputVertical * 10);
        Debug.Log("moveForward"+moveForward);

        //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(moveForward);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        Vector3 GetForward = new Vector3(inputHorizontal, 0, inputVertical).normalized;

        Vector3 Dmoves = moveSpeed * GetForward * 3;
        Debug.Log(Dmoves);

        //rb.AddForce(new Vector3(inputHorizontal, 0, inputVertical) + moveSpeed * moveForward, ForceMode.Impulse);
        rb.AddForce(moveSpeed * GetForward * 3, ForceMode.Impulse);
        Debug.Log("GetForward" + GetForward);

    }

    /*
   void FixedUpdate()
   {

       Vector3 cameraForward = transform.position - lastmov_f;

       // 方向キーの入力値とカメラの向きから、移動方向を決定
       //Vector3 moveForward = cameraForward.normalized * inputVertical + Camera.main.transform.right * inputHorizontal;
       Vector3 moveForward = cameraForward + new Vector3(inputHorizontal, 0, inputVertical);

       //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
       Quaternion targetRotation = Quaternion.LookRotation(moveForward);

       transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

       rb.AddForce(new Vector3(inputHorizontal, 0, inputVertical) + moveSpeed * moveForward * 2, ForceMode.Impulse);

       lastmov_f = transform.position;
   }
   */

}
