using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Rigidbody rigidbody = GetComponent<Rigidbody>();

		// xとzに10をかけて押す力をアップ
		rigidbody.AddForce(x * 50, 0, z * 50);
	}
}