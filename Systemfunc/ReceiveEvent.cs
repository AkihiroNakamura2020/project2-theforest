using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveEvent : MonoBehaviour
{
	Vector3 originpos;
	Vector3 movepos;
	Vector3 heading;
	Vector3 direction;
	public Vector3 directionfix;

	public bool onflash = false;

	bool cooldown = false;

	float countTime = 0;

	[SerializeField]
	int maxtime = 3;

	private void Start()
    {
		Transform transform = GetComponent<RectTransform>();
		originpos = transform.position;
	}

	/*
	void Update()
	{
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
	}
	*/

	public void MyDragUI()//Drag
	{
        if (cooldown != true)
		{
			transform.position = Input.mousePosition;
		}
		
	}

	public void MyDragExit()//pointerupへ
	{
		movepos = transform.position;
		Dragsimulate();
		transform.position = originpos;
		//cooldown = true;
	}
	/*
	public void MyDragIn()//pointerdown
	{
		PlayerWarp playerWarp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWarp>();
		playerWarp.GhostActive();
	}
	*/

	public void Dragsimulate()
	{
		heading = movepos - originpos;
		var distance = heading.magnitude;
		direction = heading / distance;
		Debug.Log(direction);

		directionfix = new Vector3(direction.x,0,direction.y);//2dから3dへ変換
		Debug.Log(directionfix);
		onflash = true;
		}
}
