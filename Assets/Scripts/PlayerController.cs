using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameManage game;
	public GameObject[] Projectile;
	public GameObject arrow;
	public LayerMask notToHit;
	public float power;

	private Transform firepoint;
	private int index;

	private int Knifes,Stones;

	void Awake(){	
		index = 0;	
		firepoint = arrow.transform.Find("FirePoint");
		if (firepoint==null) {
			Debug.Log ("Couldnt find firepoint");
		}
		InitialAmmo();
	}


	public void InitialAmmo()
	{
		Knifes = 5;
		Stones = 5;
	}

	public int ReturnCurrentKnifes()
	{
		return Knifes;
	}

	public int ReturnCurrentStones()
	{
		return Stones;
	}

	void Start () 
	{		
		
	}
	
	public void ShootProjectiles()
	{
		if (game.GetComponent<GameManage> ().isKnife == true) {
			index = 0;
		} else {
			index = 1;
		}

		if (Knifes>0 &&game.GetComponent<GameManage> ().isKnife == true) {
			Shoot (index);
		}

		if (Stones>0&&game.GetComponent<GameManage> ().isStone == true) {
			Shoot (index);
		}

	 }

	public void Shoot(int i)
	{
		i = index;
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firepoint.position.x,firepoint.position.y);
		GameObject obj;
		obj = Instantiate (Projectile[i],firepoint.position,firepoint.rotation) as GameObject;
		obj.GetComponent<Rigidbody2D> ().AddForce (firepoint.right*100f*power);

		//To check the line of shooting
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition,mousePosition-firePointPosition,100,notToHit);
		Debug.DrawLine (firePointPosition,mousePosition);
		if (i == 0) {
			Knifes--;
		} else {
			Stones--;
		}
		game.GetComponent<GameManage> ().SetAmmo ();
	}

	void Update ()
	{		
		if (Knifes==0 && Stones==0)
		{
			
		}
	}
}
