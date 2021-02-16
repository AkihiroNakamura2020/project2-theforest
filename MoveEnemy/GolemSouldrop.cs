using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSouldrop : MonoBehaviour
{
    GameObject targetobj;

    public bool dropflag=false;

    [SerializeField]
    GolemSoulCounter golemSoulCounter;

    Rigidbody rb;

    bool stayitem=false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            if(collision.gameObject != targetobj)
            {
                targetobj = collision.gameObject;
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);

                golemSoulCounter.SoulCounterplus();
                stayitem = false;
            }
        }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    void Update()
    {
        Vector3 offset = new Vector3(0, 3, 0);

        if (!dropflag && targetobj!=null&& !stayitem)
        {
            this.transform.position = targetobj.transform.position + offset;
        }

    }

    public void Dropgolemitem()
    {
        this.gameObject.SetActive(true);
    }

    public void ReDropgolemitem()
    {
        stayitem = true;

        Vector3 offset = new Vector3(0, 3, 0);
        this.transform.position = targetobj.transform.position + offset;

        rb.velocity = targetobj.transform.forward * 2;

        this.gameObject.SetActive(true);

    }
}

