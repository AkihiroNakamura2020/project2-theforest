using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveAIEnemy2 : MonoBehaviour
{
	private SetPosition setPosition;

	//　エージェント
	private NavMeshAgent navMeshAgent;

	void Start()
	{
		setPosition = GetComponent<SetPosition>();
		setPosition.CreateRandomPosition(); //目的地設定


		navMeshAgent = GetComponent<NavMeshAgent>();

	}

	void Update()
	{
		navMeshAgent.SetDestination(setPosition.GetDestination());//NavMeshAgentの「SetDestination」を使用して移動を開始
		
		if (navMeshAgent.remainingDistance < 0.5f)
		{
			setPosition.CreateRandomPosition();
		}

	}

	public void NavStop()
	{
		navMeshAgent.isStopped = true;//停止
		//navMeshAgent.acceleration = 0;
		//navMeshAgent.speed = 0.5f;
		//navMeshAgent.angularSpeed = 0;
		StartCoroutine("Restartmove");
	}

	private IEnumerator Restartmove()
	{
	
		yield return new WaitForSeconds(2);
		navMeshAgent.isStopped = false;
		//navMeshAgent.acceleration = 8;
		//navMeshAgent.speed = 3;
		//navMeshAgent.angularSpeed = 120;

	}

}