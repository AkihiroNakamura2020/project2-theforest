using UnityEngine;
using System.Collections;

public class BulletAttack : MonoBehaviour
{
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);

			//Destroy(col.gameObject);
			Decoy decoy = col.gameObject.GetComponent<Decoy>();
			decoy.OneDamage();
		}
	}

}