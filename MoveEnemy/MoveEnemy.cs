using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
	//　目的地
	private Vector3 destination;
	//　歩くスピード
	[SerializeField]
	private float walkSpeed = 1.0f;
	//　速度
	private Vector3 velocity;
	//　移動方向
	private Vector3 direction;

	private Rigidbody rigd;

	private bool arrived;

	private SetPosition setPosition;

	//　待ち時間
	[SerializeField]
	private float waitTime = 1.5f;
	//　経過時間
	private float elapsedTime;

	//　敵の状態
	private EnemyState state;
	//　追いかけるキャラクター
	private Transform playerTransform;

	//　エージェント
	private NavMeshAgent navMeshAgent;
	//　回転スピード
	[SerializeField]
	private float rotateSpeed = 100f;

	[SerializeField]
	Animator animator;

	[SerializeField]
	GameObject rightfoot;

	bool punchflag=true;

	[SerializeField]
	GolemAttackManager golemAttackManager;

	public enum EnemyState
	{
		Walk,
		Wait,
		Chase
	};

	void Start()
	{
		rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得

		//destination = new Vector3(4, 0f, 4f);

		setPosition = GetComponent<SetPosition>();
		setPosition.CreateRandomPosition(); //目的地設定

		velocity = Vector3.zero;
		arrived = false;
		elapsedTime = 0f;

		navMeshAgent = GetComponent<NavMeshAgent>();
		SetState(EnemyState.Walk);
	}

	// Update is called once per frame
	void Update()
	{
		//animator.SetBool("Walk Forward", false);

		//　見回りまたはキャラクターを追いかける状態
		if (state == EnemyState.Walk || state == EnemyState.Chase)
		{

			animator.SetBool("Walk Forward", true);

			//　キャラクターを追いかける状態であればキャラクターの目的地を再設定
			if (state == EnemyState.Chase)
			{
				if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
				{ 
				setPosition.SetDestination(playerTransform.position);
				navMeshAgent.SetDestination(setPosition.GetDestination());
				punchflag = false;

					Debug.Log("nowchase");
					//Debug.Log(navMeshAgent.remainingDistance);
				}
			}
			
			//必要か確認
				//velocity = Vector3.zero;
				//direction = (setPosition.GetDestination() - transform.position).normalized;
				//transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
				//velocity = direction * walkSpeed;

			//　目的地に到着したかどうかの判定
			//if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
			if (navMeshAgent.remainingDistance < 2f)//0.5f
			{
				//Debug.Log("Walktime");

				animator.SetBool("Walk Forward", false);
				
				//golemAttackManager.damageflag = false;
				SetState(EnemyState.Wait);
				//animator.SetTrigger("Punch Attack");
				//Punch Attack
				//StartCoroutine("WaitAnimationfin");
			}
		}
		else if (state == EnemyState.Wait)
		{
			Debug.Log("nowwait");

			if (punchflag==false)
			{
				animator.SetTrigger("Punch Attack");
				Debug.Log("Punch Attack");

				StartCoroutine("WaitAnimationfin");
				
				punchflag = true;
			}


			//elapsedTime += Time.deltaTime;
			elapsedTime += Time.fixedDeltaTime;

			//Debug.Log(elapsedTime);

			//　待ち時間を越えたら次の目的地を設定
			if (elapsedTime > waitTime)
			{
				//Debug.Log("Waittime");

				SetState(EnemyState.Walk);
				animator.SetBool("Walk Forward", true);
			}
		}
		//必要か確認
		//velocity.y += Physics.gravity.y * Time.deltaTime;
		//rigd.velocity = velocity;
	}
	/*
	void Update()
	{
		if (!arrived)
		{
			velocity = Vector3.zero;

			direction = (destination - transform.position).normalized;
			transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));

			velocity = direction * walkSpeed;
			Debug.Log(destination);

			//velocity.y += Physics.gravity.y * Time.deltaTime;
			rigd.velocity = velocity;

			if (Vector3.Distance(transform.position, destination) < 0.5f)
			{
				arrived = true;
			}
		}
		else
		{
			elapsedTime += Time.deltaTime;

			//　待ち時間を越えたら次の目的地を設定
			if (elapsedTime > waitTime)
			{
				setPosition.CreateRandomPosition();
				destination = setPosition.GetDestination();
				arrived = false;
				elapsedTime = 0f;
			}
			Debug.Log(elapsedTime);
		}

	}
	*/
	IEnumerator WaitAnimationfin()
	{
		yield return new WaitForSeconds(1f);
		SphereCollider rightfootcollider = rightfoot.GetComponent<SphereCollider>();

		//rightfoot.GetComponent<SphereCollider>().enabled = true;

		Debug.Log(rightfootcollider + "rightfootcollider");
		rightfootcollider.enabled = true;

		//var state = animator.GetCurrentAnimatorStateInfo(0);
		//yield return new WaitWhile(() => state.IsName("bk_rh_right_A"));
		yield return new WaitForSeconds(1f);

		rightfootcollider.enabled = false;
		//rightfoot.GetComponent<SphereCollider>().enabled = false;
		yield return new WaitForSeconds(0.5f);
	}

	//　敵キャラクターの状態変更メソッド
	public void SetState(EnemyState tempState, Transform targetObj = null)
	{
		if (tempState == EnemyState.Walk)
		{
			arrived = false;
			elapsedTime = 0f;
			state = tempState;
			setPosition.CreateRandomPosition();
			navMeshAgent.SetDestination(setPosition.GetDestination());
			navMeshAgent.isStopped = false;
		}
		else if (tempState == EnemyState.Chase)
		{
			state = tempState;
			//　待機状態から追いかける場合もあるのでOff
			arrived = false;
			//　追いかける対象をセット
			
			playerTransform = targetObj;

            if (playerTransform.position != null)
			{
				navMeshAgent.SetDestination(playerTransform.position);
				navMeshAgent.isStopped = false;
			}
		}
		else if (tempState == EnemyState.Wait)
		{
			elapsedTime = 0f;
			state = tempState;
			arrived = true;
			velocity = Vector3.zero;
			rigd.velocity = velocity;
		}
	}
	//　敵キャラクターの状態取得メソッド
	public EnemyState GetState()
	{
		return state;
	}
}