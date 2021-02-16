using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemfollow : MonoBehaviour
{
    [SerializeField]
    GameObject golem;

    [SerializeField]
    GameObject dropitem;

    public bool dropflag=false;

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, 3, 0);

        if (!dropflag)
        {
            this.transform.position = golem.transform.position + offset;
        }
           
    }

    public void Dropgolemitem()
    {
        dropitem.SetActive(true);
    }
}
