using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeerActionlist : MonoBehaviourPunCallbacks
{
    GameObject[] Players;
    GameObject myPlayer;
    EnvPlaymove5photon envPlaymove5photon;
    DeerAtackManager deerAtackManager;
    Shrinkingfunc shrinkingfunc;
    MeshTransparentEffect meshTransparentEffect;

    [SerializeField]
    GameObject Minimap;

    [SerializeField]
    GameObject wolfimage;

    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in Players)
        {
            PhotonView photonView = player.GetComponent<PhotonView>();

            if (photonView.IsMine)
            {
                myPlayer = player;
                Debug.Log(myPlayer);
                
            }
        }
    }

    public void DeerAA()
    {
        envPlaymove5photon= myPlayer.GetComponent<EnvPlaymove5photon>();
        envPlaymove5photon.Attackmotion();
    }

    public void MiniMapOpen()
    {
        Minimap.SetActive(true);
    }

    public void Deerskill2()
    {
        meshTransparentEffect = myPlayer.GetComponentInChildren<MeshTransparentEffect>();
        meshTransparentEffect.OnTransparent();
    }

    public void Deerskill3()
    {
        shrinkingfunc = myPlayer.GetComponentInChildren<Shrinkingfunc>();
        shrinkingfunc.OnShrink();
    }

    public void Deerskill4()
    {
        deerAtackManager = myPlayer.GetComponentInChildren<DeerAtackManager>();
        deerAtackManager.Deerpowerflagon();
    }

    public void WolfImageonoff()
    {
        deerAtackManager = myPlayer.GetComponentInChildren<DeerAtackManager>();

        deerAtackManager.wolfmode = !deerAtackManager.wolfmode;
        Debug.Log("switchmode");

        if (deerAtackManager.wolfmode)
        {
            wolfimage.SetActive(true);
        }
        else
        {
            wolfimage.SetActive(false);
        }
    }

    public void DeerWskill1()
    {
        meshTransparentEffect = myPlayer.GetComponentInChildren<MeshTransparentEffect>();
        meshTransparentEffect.OnTransparent();
    }

    public void DeerWskill2()
    {
        Minimap.SetActive(true);
    }


}
