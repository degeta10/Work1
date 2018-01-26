using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float rotOffset;
	public float baseAngle=0f;

	void Start () {
		
	}

	void OnMouseDrag()
	{
		Vector3 pos=Camera.main.WorldToScreenPoint (transform.position);
		pos = Input.mousePosition - pos;
		float ang=Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (ang,Vector3.forward);
	}

	void OnMouseDown()
	{
		Debug.Log ("Called");
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		pos = Input.mousePosition - pos;
		baseAngle = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
		baseAngle-=Mathf.Atan2(transform.right.y,transform.right.x)* Mathf.Rad2Deg;
	}

	void Update ()
	{		
		
	}
}
