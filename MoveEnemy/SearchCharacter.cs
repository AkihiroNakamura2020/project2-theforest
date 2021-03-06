﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SearchCharacter : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    [SerializeField]
    NavMeshAgent navMeshAgent;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
    }

    void OnTriggerStay(Collider col)
    {
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            //　敵キャラクターの状態を取得
            MoveEnemy.EnemyState state = moveEnemy.GetState();
            //　敵キャラクターが追いかける状態でなければ追いかける設定に変更
            if (state != MoveEnemy.EnemyState.Chase)
            {
                if(navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);
                }
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }
}