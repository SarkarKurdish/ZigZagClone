using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
public static GameManager GM;

	public KeyCode gameKey = KeyCode.Mouse0; // on PC this key do all things like move

	public Animator anim; // UI animator

	[Header("UI")]
	public Text scoreText;
	public Text GameOverTextScore;
	public Text uiStorDimondText;

	public Text GameOverHighScoreUI, MenuHighScoreUI;
	public Text newRecordText;
	public Text GamePlayedText;



	[Header ("Scoring")]
	public int Score;
	public int dimond;
	int highScore;

	[HideInInspector] // private varibls to work in Scripts
	public bool isDead,gameStarted;
	public int GamePlayed;

	void Awake()
	{
		if(GM==null)
		{
			GM = this;
		}else{
			Destroy (gameObject);
		}
	}

	IEnumerator Dead()
	{
		Camera.main.transform.parent = null;
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("dead", true);
	} // when Player fall

	void Start()
	{
		GamePlayed = PlayerPrefs.GetInt("GamePlayed");

		GamePlayedText.text =	"Game Played : " + GamePlayed;

		highScore = PlayerPrefs.GetInt ("HighScore");
		dimond = PlayerPrefs.GetInt("Dimond");
		MenuHighScoreUI.text ="High Score : " + PlayerPrefs.GetInt ("HighScore").ToString ();
	}

	void Update()
	{

		if(gameStarted)
		{
			anim.SetBool ("GameStarted", true);
		}

		if(isDead)
		{
			StartCoroutine (Dead ());

			int highSoreUtilNow = PlayerPrefs.GetInt ("HighScore");
			if(Score > highSoreUtilNow)
			{
				newRecordText.gameObject.SetActive (true);
				PlayerPrefs.SetInt ("HighScore", Score);
			}

			GameOverHighScoreUI.text = PlayerPrefs.GetInt("HighScore").ToString();


		}

		uiStorDimondText.text = dimond.ToString ();
		scoreText.text = Score.ToString();
		GameOverTextScore.text = Score.ToString();
	}

	public void GetDimond(int num)
	{

		dimond += num;
		PlayerPrefs.SetInt ("Dimond", dimond);
	}


}
