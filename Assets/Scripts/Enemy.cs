using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Rigidbody2D rigibody;
	// Use this for initialization
	void Start () {
		rigibody = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Knife")) 
		{
			rigibody.velocity=new Vector2(5f,5f);			
			Debug.Log("Enemy Hit!");
		}
		if (other.gameObject.CompareTag ("Stone")) 
		{
			rigibody.velocity=Vector2.zero;
			Destroy(other.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
