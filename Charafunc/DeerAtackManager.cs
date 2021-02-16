using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeerAtackManager : MonoBehaviourPunCallbacks
{
    public float powerEnemy = 1; //攻撃力

    HPScript hPScript;

    Decoy decoy;

    [SerializeField]
    GameObject ParentObject;

    bool deerpowerflag = false;

    EnvPlaymove4 envPlaymove4;

    public bool wolfmode = false;

    //[SerializeField]
    //GameObject wolfimage;

    bool ultimateflag = false;

    Golemfollowdrop golemfollowdrop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject != ParentObject)
        {
            hPScript = other.gameObject.GetComponent<HPScript>();

            //decoy = other.gameObject.GetComponent<Decoy>();

            if (wolfmode)
            {
                hPScript.hp -= powerEnemy * 2;
                Debug.Log("wolfmode");

                if (ultimateflag)
                {
                    hPScript.hp -= powerEnemy * 100;
                    ultimateflag = false;
                    Debug.Log("ultimateultimate");

                }

            }
            else
            {
                if (!deerpowerflag)
                {
                    photonView.RPC(nameof(AttackDamage), RpcTarget.All);
                    //hPScript.hp -= powerEnemy;
                    Debug.Log("human");
                }
                else
                {
                    hPScript.hp -= powerEnemy * 2;
                    Debug.Log("human");
                    deerpowerflag = false;
                }
                    
            }

            //hPScriptE.hp -= powerEnemy;

            //if (hPScriptE.hp <= 0)
            if (hPScript.hp <= 0)
            {
                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            hPScript = other.gameObject.GetComponent<HPScript>();
            hPScript.hp -= powerEnemy;

            golemfollowdrop = other.gameObject.GetComponent<Golemfollowdrop>();

            if (hPScript.hp <= 0)
            {
                golemfollowdrop.Dropgolemitem();

                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }

        }

    }

    [PunRPC]
    void AttackDamage()
    {
        hPScript.hp -= powerEnemy;
        Debug.Log("AttackDamage");
    }

    /*
    public void Wolfmodeonoff()
    {
        wolfmode = !wolfmode;
        Debug.Log("switchmode");

        if (wolfmode)
        {
            wolfimage.SetActive(true);
        }
        else
        {
            wolfimage.SetActive(false);
        }
    }
    */

    public void ultimateattack()
    {
        ultimateflag = true;
    }

    public void Deerpowerflagon()
    {
        deerpowerflag = true;
    }

}
