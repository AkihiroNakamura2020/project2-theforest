using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envplayermove3 : MonoBehaviour
{
    Rigidbody rb;

    float moveSpeed = 1f;
    Vector3 lastmov_f;

    void Start()
    {
        // Rigidbodyコンポーネントを取得する
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Upキーで前に進む
        if (Input.GetKey("up"))
        {
           
            Vector3 moveForward = transform.position + transform.forward * 100;
            moveForward.y = 0;
            Debug.Log("moveForward" + moveForward);

            //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(moveForward);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            rb.position = transform.position + transform.forward * 10.0f * Time.deltaTime;

            //MoveGo();
        }
        // Downキーで後ろに進む
        if (Input.GetKey("down"))
        {
            Vector3 moveForward = transform.position - transform.forward * 100;
            moveForward.y = 0;
            Debug.Log("moveForward" + moveForward);

            //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(moveForward);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            rb.position = transform.position - transform.forward * 10.0f * Time.deltaTime;
            //MoveGo();
        }
        //right キーで右に進む
        if (Input.GetKey("right"))
        {
            Vector3 moveForward = transform.position + transform.right * 300;
            moveForward.y = 0;
            Debug.Log("moveForward" + moveForward);

            //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(moveForward);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            rb.position = transform.position + transform.right * 10.0f * Time.deltaTime;
            Debug.Log(rb.position);
            //MoveGo();
        }
        //left キーで左に進む
        if (Input.GetKey("left"))
        {
            Vector3 moveForward = transform.position - transform.right * 300;
            moveForward.y = 0;
            Debug.Log("moveForward" + moveForward);

            //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(moveForward);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            rb.position = transform.position - transform.right * 10.0f * Time.deltaTime;
            //MoveGo();
        }
    }
    /*
    void MoveGo()
    {
        Vector3 cameraForward = transform.position;
        cameraForward.y = 0;

        lastmov_f.y = 0;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        //Vector3 moveForward = cameraForward.normalized * inputVertical + Camera.main.transform.right * inputHorizontal;
        Vector3 moveForward = cameraForward - lastmov_f + new Vector3(inputHorizontal * 10, 0, inputVertical * 10);
        Debug.Log("moveForward" + moveForward);

        //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(moveForward);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        Vector3 GetForward = new Vector3(inputHorizontal, 0, inputVertical).normalized;

        Vector3 Dmoves = moveSpeed * GetForward * 3;
        Debug.Log(Dmoves);

        //rb.AddForce(new Vector3(inputHorizontal, 0, inputVertical) + moveSpeed * moveForward, ForceMode.Impulse);
        rb.AddForce(moveSpeed * GetForward * 3, ForceMode.Impulse);
        Debug.Log("GetForward" + GetForward);

        lastmov_f = transform.position;

    }
    */
}