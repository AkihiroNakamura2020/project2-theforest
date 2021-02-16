using UnityEngine;
using System.Collections;
 
public class AppearScript : MonoBehaviour
{
	//　出現させる敵の格納
	[SerializeField] GameObject[] enemys;
	//　出現時間
	[SerializeField] float appearNextTime;
	//　生成可能数
	[SerializeField] int maxNumOfEnemys;
	//　生成総数
	private int numberOfEnemys;
	//　次弾待機計測
	private float elapsedTime;

	void Start()
	{
		numberOfEnemys = 0;
		elapsedTime = 0f;
	}

	void Update()
	{
		//　この場所から出現する最大数を超えてたら何もしない
		if (numberOfEnemys >= maxNumOfEnemys)
		{
			return;
		}
		//　経過時間を足す
		elapsedTime += Time.deltaTime;

		//　経過時間が経ったら
		if (elapsedTime > appearNextTime)
		{
			elapsedTime = 0f;

			AppearEnemy();
		}
	}
	//　敵出現メソッド
	void AppearEnemy()
	{
		//　出現させる敵をランダムに選ぶ
		var randomValue = Random.Range(0, enemys.Length);
		//　敵の向きをランダムに決定
		var randomRotationY = Random.value * 360f;

		GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

		numberOfEnemys++;
		elapsedTime = 0f;
	}
}