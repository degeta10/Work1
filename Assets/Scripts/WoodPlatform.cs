using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlatform : MonoBehaviour {

	private Rigidbody2D rigibody;

	// Use this for initialization
	void Start () {
		rigibody = GetComponent<Rigidbody2D> ();

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Knife")) 
		{
			rigibody.velocity=Vector2.zero;
			other.rigidbody.velocity=Vector2.zero;
			Debug.Log("Knife Hit on Wooden Platform");
		}

		if (other.gameObject.CompareTag ("Enemy")) 
		{
			rigibody.velocity=new Vector2(2f,2f);
			Debug.Log("Stone Hit on Wooden Platform");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
