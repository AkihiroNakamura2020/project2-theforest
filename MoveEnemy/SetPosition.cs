using UnityEngine;
using System.Collections;

public class SetPosition : MonoBehaviour
{
	//初期位置
	private Vector3 startPosition;
	//目的地
	private Vector3 destination;

	void Start()
	{
		//　初期位置を設定
		startPosition = transform.position;
	}

	//　ランダムな位置の作成
	public void CreateRandomPosition()
	{
		var randDestination = Random.insideUnitCircle * 4;
		//　現在地にランダムな位置を足して目的地にする
		SetDestination(startPosition + new Vector3(randDestination.x, 0, randDestination.y));
	}

	//　目的地設定
	public void SetDestination(Vector3 position)
	{
		destination = position;
	}

	//　目的地取得
	public Vector3 GetDestination()
	{
		return destination;
	}
}