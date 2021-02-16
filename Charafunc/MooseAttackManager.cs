using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MooseAttackManager : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力

    HPScriptE hPScriptE;

    Decoy decoy;

    [SerializeField]
    GameObject ParentObject;

    EnvPlaymove4 envPlaymove4;

    bool wolfmode = false;

    [SerializeField]
    GameObject wolfimage;

    bool ultimateflag = false;

    GameObject darkpanel;

    [SerializeField]
    GameObject drone1down;

    [SerializeField]
    GameObject drone2up;

    bool healingmoose = false;

    bool stopmoose = false;


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
                if (!healingmoose)
                {
                    decoy.hp -= powerEnemy;
                }
                else
                {
                    decoy.hp += powerEnemy;

                }
                Debug.Log("human");
            }

            if (stopmoose)
            {
                envPlaymove4 = other.gameObject.GetComponent<EnvPlaymove4>();
                envPlaymove4.Moosestop();
                stopmoose = false;
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

    public void Drone1func()
    {
        drone1down.SetActive(true);
    }

    public void Drone2func()
    {
        drone2up.SetActive(true);
    }

    public void Findwolffunc()
    {
        ParticlePlay youwolf = GameObject.FindWithTag("Findwolf").GetComponent< ParticlePlay>();
        youwolf.ParticleOn();

    }

    public void Healingfunc()
    {
        healingmoose = true;
    }

    public void Stopfunc()
    {
        stopmoose = true;
    }

    public void GetTargetRay()
    {
        float search_radius = 5f;

        var hits = Physics.SphereCastAll(transform.position, search_radius, transform.forward, 0.01f).Select(h => h.transform.gameObject).ToList();

        if (0 < hits.Count())
        {
            foreach (var hit in hits)
            {
                Debug.Log(hit);
                if (hit.tag == "Player" && hit != ParentObject)
                {
                    decoy = hit.GetComponent<Decoy>();
                    decoy.hp -= powerEnemy;
                }
            }

        }
    }

}

