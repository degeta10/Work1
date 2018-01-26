using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public Sprite[] sprites;

	private Rigidbody2D rigibody;
	private SpriteRenderer s;
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
	void Start () {
		SpriteReset ();
		vMove = wind + new Vector3(0.0f, riseSpeed, 0.0f);
		rigibody = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Wood")) 
		{
			i = 1;
			rigibody.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			transform.parent = other.transform;
			transform.GetComponent<SpriteRenderer>().sprite=sprites[i];
			isBaloon = true;
			Debug.Log("Stone Hit Wood");
		}
		if (other.gameObject.CompareTag ("Concrete"))
		{
			Debug.Log("Stone Hit Concrete");
		}
		SpriteReset ();
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

	// Update is called once per frame
	void Update ()
	{
		if (isBaloon) {
			Rise ();
		}
		
	}
}
