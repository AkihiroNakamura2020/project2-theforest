using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemfollowdrop : MonoBehaviour
{
    [SerializeField]
    GameObject dropitem;

    [SerializeField]
    Golemfollow golemfollow;

    public void Dropgolemitem()
    {
        golemfollow.dropflag = true;
        dropitem.SetActive(true);
    }
}
