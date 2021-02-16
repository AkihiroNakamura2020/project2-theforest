using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{
	public float speed =3.0f; //プレイヤーの動くスピード

	private Vector3 Player_pos; //プレイヤーのポジション
	private Rigidbody rigd;

	[SerializeField]
	ReceiveEvent receiveEvent;

	void Start()
	{
		Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
		rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得
	}

	void FixedUpdate()
	{
        if (receiveEvent.onflash)
		{
			transform.rotation = Quaternion.LookRotation(receiveEvent.directionfix);

			//rigd.velocity = transform.forward * speed;
			rigd.position = transform.position + transform.forward * 3.0f;

			receiveEvent.onflash = false;
		}
	}
}
