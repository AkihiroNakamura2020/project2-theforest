using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearAttackManager : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力

    HPScriptE hPScriptE;

    Decoy decoy;

    [SerializeField]
    GameObject ParentObject;

    int bearpower = 1;

    bool bearpowerflag = false;

    EnvPlaymove4 envPlaymove4;

    bool wolfmode = false;

    [SerializeField]
    GameObject wolfimage;

    [SerializeField]
    GameObject prefabmonster;

    bool ultimateflag = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject != ParentObject)
        {
            //hPScriptE = other.gameObject.GetComponent<HPScriptE>();

            decoy = other.gameObject.GetComponent<Decoy>();

            if (wolfmode)
            {
                decoy.hp -= powerEnemy * 2;
                Debug.Log("wolfmode");

                if (ultimateflag)
                {
                    decoy.hp -= powerEnemy * 100;
                    ultimateflag = false;
                    Debug.Log("ultimateultimate");

                }

            }
            else
            {
                decoy.hp -= powerEnemy* bearpower;
                Debug.Log("human");

                if (bearpowerflag)
                {
                    BearPowerback();
                }
            }

            //hPScriptE.hp -= powerEnemy;

            //if (hPScriptE.hp <= 0)
            if (decoy.hp <= 0)
            {
                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }
        }
    }

    public void BearPowerUp()
    {
        bearpower = 2;
        bearpowerflag = true;
    }

    void BearPowerback()
    {
        bearpower = 1;
        bearpowerflag = false;
    }

    public void BearSuperPowerUp()
    {
        bearpower = 3;
        bearpowerflag = true;
    }

    public void Monstercoming()
    {
        Instantiate(prefabmonster);
    }

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

    public void ultimateattack()
    {
        ultimateflag = true;
    }

}