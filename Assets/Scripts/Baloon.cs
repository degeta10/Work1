using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour {

	public Sprite[] sprites;

	private Rigidbody2D rigibody;
	private int i;
	private bool isBaloon = false;


	//Baloon Mechanics
	float rotateAmount= 15f;
	float rotateSpeed= 2f;
	float riseSpeed= 1.0f;
	float angle= 0.0f;
	private Vector3 vMove;
	Vector3 wind = new Vector3(0.0f, 0f, 0f);

	// Use this for initialization
	void Start ()
	{
		SpriteReset ();
		vMove = wind + new Vector3(0.0f, riseSpeed, 0.0f);
		rigibody = GetComponent<Rigidbody2D> ();
	}

	void SpriteReset()
	{
		i = 0;
		Debug.Log("Sprite has been reset");
	}

	void Rise()
	{
		angle = Mathf.Sin(Time.time * rotateSpeed) * rotateAmount;
		transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
		transform.position += vMove * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Wood")) 
		{
			i = 1;
			transform.GetComponent<SpriteRenderer> ().sprite = sprites [i]; //Sprite Changed To Baloon
			rigibody.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; //Changed to Kinematic to its gets stuck to wooden block
			rigibody.velocity=Vector2.zero; //Killing the velocity of baloon
			other.transform.parent=transform; //Set Wooden Block as child of Baloon GameObject
			other.rigidbody.bodyType=RigidbodyType2D.Dynamic;
			
			transform.gameObject.AddComponent<HingeJoint2D> ();
			transform.GetComponent<HingeJoint2D>().connectedBody=other.transform.GetComponent<Rigidbody2D>();
			transform.GetComponent<HingeJoint2D> ().anchor =new  Vector2(-0.1429915f,-9.342112f);
			transform.GetComponent<HingeJoint2D> ().connectedAnchor = new Vector2(0.9928504f,-1.767106f);
			isBaloon = true;
			Debug.Log("Stone Hit Wood");
		}
		if (other.gameObject.CompareTag ("Concrete"))
		{
			Debug.Log("Stone Hit Concrete");
		}

		if (other.gameObject.CompareTag ("Enemy")) 
		{
			Destroy (gameObject);
		}
		SpriteReset ();
	}

	
	// Update is called once per frame
	void Update () {
		if (isBaloon) {
			Rise ();
		}
		
	}
}
