using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setwarp : MonoBehaviour
{
	public Vector3 cube_pos;
	
	[SerializeField]
	warpController warpcontroller;

	[SerializeField]
	GameObject warpplayer;

	void Start()
	{
		cube_pos = GetComponent<Transform>().position; 
	}

	void FixedUpdate()
	{
		cube_pos = GetComponent<Transform>().position;

		if (warpcontroller.onwarp == true)
		{
			if (this.transform.parent != null)
			{
				this.transform.parent = null;
	
			}
		}
	}
}
