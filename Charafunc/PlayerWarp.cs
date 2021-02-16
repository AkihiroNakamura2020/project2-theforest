using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
	public float speed = 3.0f; //プレイヤーの動くスピード

	//private Vector3 Player_pos; //プレイヤーのポジション
	private Rigidbody rigd;

	[SerializeField]
	ReceiveEventGhost receiveEventGhost;

	[SerializeField]
	GameObject playerghost;

	//Collider Ghostmode;

	void Start()
	{
		//Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
		//rigd = playerghost.GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得
		//Ghostmode = GetComponent<Collider>();
	}

	public void GhostActive()
	{
		//Ghostmode.isTrigger = true;
		playerghost.SetActive(true);
	}

	public void GhostDeactive()
	{
		transform.position = playerghost.transform.position;
		playerghost.SetActive(false);
		//Ghostmode.isTrigger = false;
	}

	void Update()
	{
		if (receiveEventGhost.onDrag)
		{
			if (receiveEventGhost.distance != 0)
			{
				playerghost.transform.rotation = Quaternion.LookRotation(receiveEventGhost.directionfix);

				//rigd.position = transform.position + receiveEventGhost.directionfix * 3.0f;

				playerghost.transform.position = playerghost.transform.position + receiveEventGhost.directionfix * 0.1f;

				//Vector3 targetposition = playerghost.transform.position + receiveEventGhost.directionfix * 3.0f;
				//playerghost.transform.position = Vector3.Lerp(playerghost.transform.position, targetposition,Time.deltaTime);

				//Debug.Log("playerghost.transform.position" + playerghost.transform.position);
			}
        }
        else
		{
			playerghost.transform.position = transform.position;

		}

		/*
		if (receiveEvent.onghost)//ボタンの移動計算が終了してからの動作にしたいので
		{
			transform.rotation = Quaternion.LookRotation(receiveEvent.directionfix);

			//rigd.velocity = transform.forward * speed;
			rigd.position = transform.position + transform.forward * 3.0f;

			receiveEvent.onflash = false;
		}
		*/
	}
}
