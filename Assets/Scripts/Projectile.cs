using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private Rigidbody2D rigibody;
	// Use this for initialization
	void Start () {
		rigibody = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			rigibody.bodyType = RigidbodyType2D.Kinematic;
			transform.parent = other.transform;
			Debug.Log("Knife Hit Enemy");
		}
		
		if (other.gameObject.CompareTag ("Wood")) {
			rigibody.bodyType = RigidbodyType2D.Kinematic;
			rigibody.velocity=Vector2.zero;
			transform.parent = other.transform;
		} 
		//Destroy (gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
