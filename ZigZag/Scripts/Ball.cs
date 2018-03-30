using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	KeyCode movementKey; // this key make your ball goes left or forward and this source can be found in GAME MANAGER (gameKey)
	public float speed; // the speed of ball movement
	public AudioClip Tapclip;
	public AudioClip Fallclip;

	AudioSource source;
	Touch tch; // 
	//PrivetVariabls
	[HideInInspector]
	public float r,b,g; // our color in RGB

	[HideInInspector]
	public Vector3 dir; // privte vector tell us what direction should we go
	bool heIN; // check ball hit collider it mean when he left collider he's die


	bool oneFallSound =true;// one time play fall sound

	#region Singltion
	public static Ball ball;

	void Awake()
	{
		if(ball ==null)
		{
			ball = this;
		}else {
			Destroy (gameObject);
		}
	}

	#endregion

	void Start () {

		#region Get Same Color we use  When we close game
		r= PlayerPrefs.GetFloat ("r");
		b= PlayerPrefs.GetFloat ("b");
		g= PlayerPrefs.GetFloat ("g");

		var  color = GetComponent<Renderer> ().material.color;
		color.r = r;
		color.b = b;
		color.g = g;

		GetComponent<Renderer> ().material.color = color;

		#endregion
		source = GetComponent<AudioSource> ();
		dir = Vector3.zero; 
		movementKey = GameManager.GM.gameKey;
	}
	

	void Update () {
		if (!GameManager.GM.gameStarted) return;

		if(transform.position.y <1.5) // this value 1.5 is our ball transform from y if he goes less then it wich it mean his fallen down we can detect it imendetly
		{
			GameManager.GM.isDead = true;
			if (oneFallSound) {
				source.PlayOneShot (Fallclip);
				oneFallSound = false;
			}
		}
		transform.Translate (dir * Time.deltaTime * speed,Space.World); // Move Object In World Space

		Move (movementKey);
	}


	void Move(KeyCode key) 
	{
		if (!GameManager.GM.gameStarted) return;
		int touchs = Input.touchCount;

		//PC Input
		if (!GameManager.GM.isDead) {
			if (Input.GetKeyDown (key) && dir != Vector3.left) {
				dir = Vector3.left;
				GameManager.GM.Score++;
				source.PlayOneShot (Tapclip);

			} else if (Input.GetKeyDown (key) && dir != Vector3.forward) {
				dir = Vector3.forward;
				GameManager.GM.Score++;
				source.PlayOneShot (Tapclip);
			}
		}


		//Phone Touch input
		if (!GameManager.GM.isDead) {
			
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && dir != Vector3.left) {
				// tch = Input.GetTouch (1);
				dir = Vector3.left;
				GameManager.GM.Score++;
				source.PlayOneShot (Tapclip);

			} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && dir != Vector3.forward) {
				//tch = Input.GetTouch (1);
				dir = Vector3.forward;
				GameManager.GM.Score++;
				source.PlayOneShot (Tapclip);
			}
		}
	}


}
