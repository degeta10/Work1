using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreddor : MonoBehaviour {

	public GameManage game;
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name=="Enemy")
		{
			game.GetComponent<GameManage>().Score+=1000;
			game.GetComponent<GameManage>().SetScore();
		}
		Destroy(col.gameObject);
	}

}
