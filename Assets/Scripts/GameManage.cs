using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour {

	public PlayerController player;
	public string MainScene,LevelScene;
	public CanvasRenderer canvas;
	public Text knifes,stones,score,Result,ResultingScore;

	private bool pause;
	private bool playClicked;
	private bool levelClicked;
	public bool isKnife;
	public bool isStone;

	public int Knifes,Stones,Score;

	void Start () 
	{	
		Score = 0000;//Initial Score
		pause = false;
		playClicked = false;
		levelClicked = false;
		DeActivatePauseMenu ();
		SetAmmo ();
		SetScore ();
		InitialProjectile ();
	}

	public void InitialProjectile()
	{
		isKnife = true;
		isStone = false;
	}

	public void SetScore()
	{
		if (Score==0) {
			score.text = "0000";			
		}
		score.text = Score.ToString();
		//score.text = "0000";
		ResultingScore.text = "SCORE : "+Score.ToString ();
		//ResultingScore.text = "SCORE : "+"0000";
	}

	public void SetAmmo()
	{		
		knifes.text = player.GetComponent<PlayerController> ().ReturnCurrentKnifes ().ToString();
		stones.text = player.GetComponent<PlayerController> ().ReturnCurrentStones().ToString();
	}

	public void knifeSelected()
	{
		Debug.Log ("Knife Selected");
		isKnife = true;
		isStone = false;

	}

	public void stoneSelected()
	{
		Debug.Log ("Stone Selected");
		isStone = true;
		isKnife = false;
	}

	public void DeActivatePauseMenu()
	{		
		canvas.gameObject.SetActive (false);
	}

	public void PlayClicked()
	{
		playClicked = true;
		SceneChanger (MainScene);
	}

	public void LevelClicked()
	{
		levelClicked = true;
		SceneChanger (LevelScene);
	}

	public void OnPauseClicked()
	{
		if (pause == true) {
			pause = false;
			DeActivatePauseMenu ();
		} else
			pause = true;

		Debug.Log (pause);
	}

	public void Win()
	{
		SetScore();
		Result.text="YOU WIN";	
		ActivatePauseMenu();			
	}

	public void GameOver()
	{
		SetScore();
		Result.text = "GAME OVER";
		ActivatePauseMenu();	
	}

	public void SceneChanger(string scene)
	{		
		SceneManager.LoadScene (scene);	
	}

	public void CloseGame()
	{
		Application.Quit ();
	}

	public void ActivatePauseMenu()
	{
		canvas.gameObject.SetActive (true);
	}

	public void RestartScene()
	{
		SceneChanger (MainScene);
	}

	// Update is called once per frame
	void Update () 
	{
		int n;

		n=GameObject.FindGameObjectsWithTag("Enemy").Length;
		Knifes = player.GetComponent<PlayerController> ().ReturnCurrentKnifes ();
		Stones=player.GetComponent<PlayerController> ().ReturnCurrentStones ();
		
		if (pause==true) {
			ActivatePauseMenu ();
		}
		if ( n==0 )
		{
			Win();
		}

		if ((Knifes==0 && Stones==0)&&n>0)
		{
			GameOver();
		}
	}
}
