using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodManager : MonoBehaviour
{
    public float powerEnemy = 1; //攻撃力

    HPScriptE hPScriptE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hPScriptE = other.gameObject.GetComponent<HPScriptE>();
            //hPScriptE.GetDamage(powerEnemy);
            hPScriptE.hp -= powerEnemy;

            if (hPScriptE.hp <= 0)
            {
                Destroy(other.gameObject);  //ゲームオブジェクトが破壊される
            }
        }
    }
}
