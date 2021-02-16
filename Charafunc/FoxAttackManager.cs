using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxAttackManager : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力

    HPScriptE hPScriptE;

    Decoy decoy;

    [SerializeField]
    GameObject ParentObject;

    bool foxdarkflag = false;

    EnvPlaymove4 envPlaymove4;

    bool wolfmode = false;

    [SerializeField]
    GameObject wolfimage;

    bool ultimateflag = false;

    GameObject darkpanel;

    [SerializeField]
    GameObject prefabdummy;

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
                decoy.hp -= powerEnemy;
                Debug.Log("human");
            }

            if (foxdarkflag)
            {
                envPlaymove4 = other.gameObject.GetComponent<EnvPlaymove4>();
                envPlaymove4.DarkPanelon();
            }

            //hPScriptE.hp -= powerEnemy;

            //if (hPScriptE.hp <= 0)
            if (decoy.hp <= 0)
            {
                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }
        }
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

    public void FoxDarkfunc()
    {
        foxdarkflag = true;
    }

    public void dummyfoxcoming()
    {
       GameObject obj = Instantiate(prefabdummy);
        obj.transform.position = transform.position;
    }

}

