using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FieldonEnter : MonoBehaviour
{
    Rigidbody rb;
    MoveAIEnemy2 CubeMove;

    private void Start()
    {
        //GetComponent<SphereCollider>().enabled = false;
    }

    public void GetTargetfreeze()
    {
        float search_radius = 5f;

        var hits = Physics.SphereCastAll(transform.position,search_radius,transform.forward, 0.01f).Select(h => h.transform.gameObject).ToList();

        if (0 < hits.Count())
        {
            foreach (var hit in hits)
            {
                Debug.Log(hit);
                if (hit.tag == "Enemy")
                {
                    CubeMove = hit.GetComponent<MoveAIEnemy2>();
                    CubeMove.NavStop();

                    //rb = hit.GetComponent<Rigidbody>();
                    //rb.constraints = RigidbodyConstraints.FreezeAll;
                }
            }

        }
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void OnField()
    {
        GetComponent<SphereCollider>().enabled = true;
    }
    */
}
