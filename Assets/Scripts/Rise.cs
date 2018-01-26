using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour {

	float rotateAmount= 15f;
	float rotateSpeed= 2f;
	Vector3 wind = new Vector3(0.0f, 0f, 0f);
	float riseSpeed= 1.0f;

	float angle= 0.0f;

	private Vector3 vMove;
	// Use this for initialization
	void Start () {
		vMove = wind + new Vector3(0.0f, riseSpeed, 0.0f);
	}

	void RiseUp()
	{
		angle = Mathf.Sin(Time.time * rotateSpeed) * rotateAmount;
		transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
		transform.position += vMove * Time.deltaTime;
		//transform.GetComponent<HingeJoint2D> ().connectedBody = GameObject.Find ("Wood").GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		RiseUp ();
	}
}
