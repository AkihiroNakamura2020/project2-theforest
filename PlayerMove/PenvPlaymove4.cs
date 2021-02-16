using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PenvPlaymove4 : MonoBehaviourPunCallbacks
{
    Rigidbody rb;

    float moveSpeed = 1f;
    Vector3 lastmov_f;

    bool Inverseflag = true;

    void Start()
    {
        // Rigidbodyコンポーネントを取得する
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField]
    Animator animator;

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            // Upキーで前に進む
            if (Input.GetKey("up"))
            {
                Inverseflag = true;

                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    animator.SetTrigger("playwalking");
                }

                Vector3 moveForward = transform.position + transform.forward * 100;
                moveForward.y = 0;

                //Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

                rb.position = transform.position + transform.forward * 10.0f * Time.deltaTime;

                //MoveGo();
            }
            // Downキーで後ろに進む
            if (Input.GetKey("down"))
            {
                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    Debug.Log("aaa");
                    animator.SetTrigger("playwalking");
                }

                if (Inverseflag)
                {
                    Vector3 moveForward = transform.position - transform.forward * 100;
                    moveForward.y = 0;
                    Debug.Log("moveForward" + moveForward);

                    //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
                    Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
                    transform.rotation = targetRotation;
                    Inverseflag = false;
                }

                rb.position = transform.position + transform.forward * 10.0f * Time.deltaTime;
                //MoveGo();
            }
            //right キーで右に進む
            if (Input.GetKey("right"))
            {

                Inverseflag = true;

                //animator.SetTrigger("playwalking");

                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    Debug.Log("aaa");
                    animator.SetTrigger("playwalking");

                }

                Vector3 moveForward = transform.position + transform.right * 500;
                moveForward.y = 0;
                Debug.Log("moveForward" + moveForward);

                //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
                //transform.rotation = targetRotation;

                //rb.position = transform.position + transform.right * 2.0f * Time.deltaTime;
                rb.position = transform.position + transform.forward * 2.0f * Time.deltaTime;

                Debug.Log(rb.position);
                //MoveGo();
            }
            //left キーで左に進む
            if (Input.GetKey("left"))
            {
                Inverseflag = true;

                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    Debug.Log("aaa");
                    animator.SetTrigger("playwalking");
                }

                Vector3 moveForward = transform.position - transform.right * 500;
                moveForward.y = 0;
                Debug.Log("moveForward" + moveForward);

                //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);

                //rb.position = transform.position - transform.right * 2.0f * Time.deltaTime;
                rb.position = transform.position + transform.forward * 2.0f * Time.deltaTime;
                //MoveGo();
            }

        }
    }
}
