using UnityEngine;
using System.Collections;

public class AddForceBullet2 : MonoBehaviour
{
	//　弾のゲームオブジェクト
	[SerializeField]
	private GameObject bulletPrefab;

	//　銃口
	[SerializeField]
	private Transform muzzle;

	//　弾を飛ばす力
	[SerializeField]
	private float bulletPower = 1000f;

	private Vector3 force;

	void Start()
	{
	}

	void Update()
	{
		
		if (Input.GetButtonDown("Fire1"))
		{
			Vector3 screenPos = Input.mousePosition; //タップ位置のスクリーン座標
			screenPos.z = 2.0f;

			Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);//ワールド座標
			//GetAim(worldPos, muzzle.position);
			GetAim(muzzle.position, worldPos);
			Shot();

			//Debug.Log("screenPos" + screenPos);
			//Debug.Log("worldPos"+worldPos);
			//Debug.Log("muzzle.position" + muzzle.position);

		}

		//タップ位置にはZ座標が含まれていない為、透視投影視のカメラでは奥行きが特定出来ない点に注意



		/*
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(ray.direction);

		RaycastHit hit;


		if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Gun")))
		{
			Cursor.visible = false;
		}
		else
		{
			Cursor.visible = true;
		}

		//　マウスの左クリックで撃つ
		if (Input.GetButtonDown("Fire1"))
		{
			Shot();
		}
		*/
	}

	public void GetAim(Vector2 p1, Vector2 p2)
	{
		//float dx = Mathf.Abs(p2.x - p1.x);
		float dy = p2.y - p1.y;

		//force = new Vector3(0, dy/dx,0);//タンジェント
		force = new Vector3(0, dy, 0);//タンジェント

		//float rad = Mathf.Atan2(dy, dx); //Tan が y/x になる角度をラジアンで返す
		//return rad * Mathf.Rad2Deg;//Rad2Degでラジアンから度数に変換

	}


	//　敵を撃つ
	public void Shot()
	{
		var bulletInstance = Instantiate<GameObject>(bulletPrefab, muzzle.position, muzzle.rotation);

		//bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
		bulletInstance.GetComponent<Rigidbody>().AddForce((bulletInstance.transform.forward + force) * bulletPower);

		Destroy(bulletInstance, 5f);
	}
}
