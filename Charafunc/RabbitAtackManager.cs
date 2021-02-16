using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitAtackManager : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力

    HPScriptE hPScriptE;

    Decoy decoy;

    [SerializeField]
    GameObject ParentObject;

    bool rabitslowflag=false;

    EnvPlaymove4 envPlaymove4;

    bool wolfmode = false;

    [SerializeField]
    GameObject wolfimage;

    bool ultimateflag=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&& other.gameObject != ParentObject)
        {
            //hPScriptE = other.gameObject.GetComponent<HPScriptE>();

            decoy = other.gameObject.GetComponent<Decoy>();

            if (wolfmode)
            {
                decoy.hp -= powerEnemy*2;
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

            

            if (rabitslowflag)
            {
                envPlaymove4 = other.gameObject.GetComponent<EnvPlaymove4>();
                StartCoroutine("Rabbitslowfunc");
                Debug.Log("rabitslowflagtrue");
            }

            //hPScriptE.hp -= powerEnemy;

            //if (hPScriptE.hp <= 0)
            if (decoy.hp <= 0)
            {
                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }
        }
    }

    public void Rabbitslow()
    {
        rabitslowflag = true;
    }

    IEnumerator Rabbitslowfunc()
    {
        envPlaymove4.rabbitspeedup = 0.8f;
        yield return new WaitForSeconds(2);
        envPlaymove4.rabbitspeedup = 1;
        rabitslowflag = false;
        Debug.Log("rabitslowflagfalse");
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
