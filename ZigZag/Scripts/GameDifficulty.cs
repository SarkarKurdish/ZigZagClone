using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour {
	public float timeIncreesBy;
	public int changeDifficultyAfter = 50; // After our score reach 50 game Difficulty will change it mean game time increes and it mean game will be more speed after difficulty change this variable pluse by another 50 wich mean this time after we reach 100 game again be more speed

	private int refInt;

	void Start()
	{
		InvokeRepeating ("ChangeSpeed", 5, 5); // its more otimized if we check it one in 5 sceond;
	}

	void ChangeSpeed () {
		refInt = GameManager.GM.Score;
		if(refInt>=changeDifficultyAfter)
		{
			Time.timeScale += timeIncreesBy;
			changeDifficultyAfter += 50;
		}
	}
}
