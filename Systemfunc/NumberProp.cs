using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class NumberProp : MonoBehaviour
{
    [SerializeField]
    GameObject faceon;

    [SerializeField]
    GameObject humanon;

    bool offwolf = false;

    public int lobbyPlayerMaxCount;


    void Update()
    {
        /*
        if (PhotonNetwork.LocalPlayer.CustomProperties["PNumber"] is int pnumber)
        {
            if (pnumber == 0)
            {
                if(offwolf == false)
                {
                    faceon.SetActive(true);
                    StartCoroutine("WolfUIoff");
                }
            }
            Debug.Log(pnumber);
        }
        */
    }

    IEnumerator WolfUIoff()
    {
        yield return new WaitForSeconds(3);
        offwolf = true;
        faceon.SetActive(false);
    }

    public void Faceon()
    {
        faceon.SetActive(true);
    }

    public void Humanon()
    {
        humanon.SetActive(true);
    }

    /*
    public void LobbyCount()
    {
        lobbyPlayerMaxCount++;

        PlayerPrefs.SetInt("Count", lobbyPlayerMaxCount);
        PlayerPrefs.Save();

        Debug.Log(lobbyPlayerMaxCount);
        moveMine.Onflag();
    }
    */


}
