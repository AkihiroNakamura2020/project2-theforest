using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpController : MonoBehaviour
{
    [SerializeField]
    GameObject warppoint;

    [SerializeField]
    Setwarp setwarp;
    
    public bool onwarp = false;

    public int warpcount = 0;

    void Start()
    {
        warppoint.SetActive(false);
 
    }

    public void Setwarp()
    {
        if (onwarp == false)
        {
            warppoint.SetActive(true);
            onwarp = true;
        }

        warpcount++;

        if (warpcount > 1)
        {
            transform.position = setwarp.cube_pos;
        }
    }
}
