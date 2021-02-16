using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveEventGhost : MonoBehaviour
{
	Vector3 originpos;
	Vector3 movepos;
	Vector3 beforemovepos;
	public Vector3 heading;
	Vector3 direction;
	public Vector3 directionfix;
	public float distance;

	PlayerWarp playerWarp;

	//public bool onflash = false;
	//bool cooldown = false;
	//float countTime = 0;
	//[SerializeField]
	//int maxtime = 3;

	public bool onDrag = false;

	private void Start()
	{
		Transform transform = GetComponent<RectTransform>();
		originpos = transform.position;
		beforemovepos = originpos;
	}

	void Update()
	{
        if (onDrag)
		{
			movepos = transform.position;
			Dragsimulate();
			Debug.Log("計算開始");
		}

		/*
		if (cooldown)
		{
			countTime += Time.deltaTime; //スタートしてからの秒数を格納
			GetComponent<Image>().fillAmount = countTime / maxtime;

			if (countTime >= 3.0f)
			{
				cooldown = false;
				countTime = 0;
			}
		}
		*/
	}

	public void MyDragIn()//pointerdown
	{
		playerWarp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWarp>();
		playerWarp.GhostActive();
		onDrag = true;
	}

	public void MyDragUI()//Drag
	{
		transform.position = Input.mousePosition;
		/*
		movepos = transform.position;
		Dragsimulate();
		transform.position = originpos;
		*/

		/*
		if (cooldown != true)
		{
			transform.position = Input.mousePosition;
		}
		*/
	}

	public void MyDragExit()//pointerupへ
	{
		//cooldown = true;
		transform.position = originpos;
		playerWarp.GhostDeactive();
		onDrag = false;
	}

	public void Dragsimulate()
	{
		heading = movepos - beforemovepos;

		distance = heading.magnitude;
		direction = heading / distance;
		Debug.Log(direction);

		directionfix = new Vector3(direction.x, 0, direction.y);//2dから3dへ変換
		Debug.Log(directionfix);

		beforemovepos = movepos;
	}
}
