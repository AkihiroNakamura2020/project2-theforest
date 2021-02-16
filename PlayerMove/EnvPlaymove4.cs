using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnvPlaymove4 : MonoBehaviourPunCallbacks
{
    Rigidbody rb;

    float moveSpeed = 1f;
    Vector3 lastmov_f;

    bool Inverseflag = true;

    [SerializeField]
    GameObject rightfoot;

    [SerializeField]
    GameObject Minimap;

    public float rabbitspeedup = 1;

    float wolfspeed= 1 ;

    [SerializeField]
    GameObject Darkpanel;

    void Start()
    {
        // Rigidbodyコンポーネントを取得する
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField]
    Animator animator;

    void FixedUpdate()
    {
        //if (photonView.IsMine)
        
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

                rb.position = transform.position + transform.forward * 10.0f * Time.deltaTime * rabbitspeedup * wolfspeed;

                //MoveGo();
            }
            // Downキーで後ろに進む
            if (Input.GetKey("down"))
            {
                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    animator.SetTrigger("playwalking");
                }

                if (Inverseflag)
                {
                    Vector3 moveForward = transform.position - transform.forward * 100;
                    moveForward.y = 0;
              
                    //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
                    Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
                    transform.rotation = targetRotation;
                    Inverseflag = false;
                }

                rb.position = transform.position + transform.forward * 10.0f * Time.deltaTime * rabbitspeedup * wolfspeed;
                //MoveGo();
            }
            //right キーで右に進む
            if (Input.GetKey("right"))
            {

                Inverseflag = true;

                //animator.SetTrigger("playwalking");

                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    animator.SetTrigger("playwalking");

                }

                Vector3 moveForward = transform.position + transform.right * 500;
                moveForward.y = 0;
         
                //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
                //transform.rotation = targetRotation;

                //rb.position = transform.position + transform.right * 2.0f * Time.deltaTime;
                rb.position = transform.position + transform.forward * 2.0f * Time.deltaTime * rabbitspeedup * wolfspeed;

                //MoveGo();
            }
            //left キーで左に進む
            if (Input.GetKey("left"))
            {
                Inverseflag = true;

                if (!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("RabbitWalk3"))
                {
                    animator.SetTrigger("playwalking");
                }

                Vector3 moveForward = transform.position - transform.right * 500;
                moveForward.y = 0;
        
                //Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(moveForward);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);

                //rb.position = transform.position - transform.right * 2.0f * Time.deltaTime;
                rb.position = transform.position + transform.forward * 2.0f * Time.deltaTime * rabbitspeedup * wolfspeed;
                //MoveGo();
            }
        
    }

    public void Attackmotion()
    {
        animator.SetTrigger("Attack1");

        photonView.RPC(nameof(DoWaitAnimation), RpcTarget.All);
        
        //StartCoroutine("WaitAnimationfin");
        Debug.Log("AttackmotionOn");
    }

    [PunRPC]
    void DoWaitAnimation()
    {
        StartCoroutine("WaitAnimationfin");
    }

    IEnumerator  WaitAnimationfin()
    {
        SphereCollider rightfootcollider = rightfoot.GetComponent<SphereCollider>();

        //rightfoot.GetComponent<SphereCollider>().enabled = true;

        Debug.Log(rightfootcollider+ "rightfootcollider");
        rightfootcollider.enabled = true;

        //var state = animator.GetCurrentAnimatorStateInfo(0);
        //yield return new WaitWhile(() => state.IsName("bk_rh_right_A"));
        yield return new WaitForSeconds(0.2f);

        rightfootcollider.enabled = false;
        //rightfoot.GetComponent<SphereCollider>().enabled = false;
    }

    public void MiniMapOpen()
    {
        Minimap.SetActive(true);
    }

    public void RabbitspeedIp()
    {
        rabbitspeedup = 1.1f;
    }

    public void RabbitDash()
    {
        StartCoroutine("RabbitDashon");
    }

    IEnumerator RabbitDashon()
    {
        rabbitspeedup = 3.0f;
        yield return new WaitForSeconds(2);
        rabbitspeedup = 1;
    }

    public void DarkPanelon()
    {
        Darkpanel.SetActive(true);
    }

    public void Moosestop()
    {
        StartCoroutine("Moosestopon");
    }

    IEnumerator Moosestopon()
    {
        rabbitspeedup = 0;
        yield return new WaitForSeconds(2);
        rabbitspeedup = 1;
    }

}
