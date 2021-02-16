using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronecamera2 : MonoBehaviour
{
	public float speed; //プレイヤーの動くスピード

	private Vector3 Player_pos; //プレイヤーのポジション
	private Vector3 Next_pos;
	private Rigidbody rigd;

	[SerializeField]
	CameraController cameraController;

	void Start()
	{
		Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
		rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得
		
	}

	void FixedUpdate()
	{
		if (cameraController.onsubc2==true)
		{
			if(this.transform.parent != null)
			{
				this.transform.parent = null;
			}
			

			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			rigd.velocity = new Vector3(x * speed, 0, z * speed); //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動
																  //Next_pos = new Vector3(x * speed, 0, z * speed);

			Vector3 diff = transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
			diff = new Vector3(diff.x, 0, diff.z);

			if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる
			{
				transform.rotation = Quaternion.LookRotation(diff);
			}

			Player_pos = transform.position; //プレイヤーの位置を更新
		}
	}

}
