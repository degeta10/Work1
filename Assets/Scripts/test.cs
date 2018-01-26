using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	
	/*float rotateAmount= 15f;
	float rotateSpeed= 2f;
	Vector3 wind = new Vector3(0.0f, 0f, 0f);
	float riseSpeed= 1.0f;

	float angle= 0.0f;

	private Vector3 vMove;
	private bool isBaloon = false;

	private Rigidbody2D rigibody;

	//public Sprite[] sprites;
	private int i;
	private bool isTouchableArea;

	public float rotOffset;*/

	public float baseAngle=0f;

	void  Start ()
	{
		
	}

	void OnMouseDown()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		pos = Input.mousePosition - pos;
		baseAngle = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
		baseAngle-=Mathf.Atan2(transform.right.y,transform.right.x)* Mathf.Rad2Deg;
	}

	void OnMouseDrag()
	{
		Vector3 pos=Camera.main.WorldToScreenPoint (transform.position);
		pos = Input.mousePosition - pos;
		float ang=Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (ang,Vector3.forward);
	}
	void  Update ()
	{

		
	}
}
