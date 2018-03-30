using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsActions : MonoBehaviour {

	public GameObject gameStartButton; // after we click to start game we went deactive start button for some reasson

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		PlayerPrefs.SetInt ("GamePlayed", GameManager.GM.GamePlayed + 1);

	}

	public void Quit()
	{
		Application.Quit();
	}

	public void openShop()
	{
		GameManager.GM.anim.SetBool ("openShop", true);
	}

	public void closeShop()
	{
		GameManager.GM.anim.SetBool ("openShop", false);

	}

	public void startGame()
	{
		GameManager.GM.gameStarted = true;
		Ball.ball.dir = Vector3.left;
		gameStartButton.SetActive (false);
	}
}
