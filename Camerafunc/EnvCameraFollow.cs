using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvCameraFollow : MonoBehaviour
{
	GameObject player;
	Vector3 offset;

	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	void Update()
	{
		Vector3 pos = player.transform.localPosition;
		offset = new Vector3(0,3,-7);

		transform.localPosition = pos + offset;
	}
}
