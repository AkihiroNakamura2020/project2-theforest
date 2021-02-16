using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttackManager : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力

    HPScript hPScript;

    public bool damageflag=false;

    [SerializeField]
    GameObject ParentObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(" OnTriggerEnterGolemAttackManager");

        if (other.gameObject.tag == "Player" && other.gameObject != ParentObject)
        {
            hPScript = other.gameObject.GetComponent<HPScript>();

            if (!damageflag)
            {
                //hPScript.hp -= powerEnemy;
                damageflag = true;
                StartCoroutine("WaitDamagefin");
            }

            if (hPScript.hp <= 0)
            {
                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }
        }
    }

    IEnumerator WaitDamagefin()
    {
        //hPScript.hp -= powerEnemy;
        yield return new WaitForSeconds(1f);
        damageflag = false;
    }

}

