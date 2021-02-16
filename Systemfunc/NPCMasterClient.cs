using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NPCMasterClient : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        { 
            Debug.Log("MasterClient");
        }
        else
        {
            Debug.Log("notMasterClient");
        }
        
    }

}
