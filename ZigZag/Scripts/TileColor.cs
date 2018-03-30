using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour {
	public float time; // drutuion color change time
	public Color[] colors;
	public Material mat; // Ground Material
	public Color startColor;// default tile color

	Color myColor;
	Camera cam;


	public int neededScore; // this score we need reach to change tils color
	void Start()
	{
		mat.color = startColor;
		cam = GetComponent<Camera> ();
		myColor = mat.color;
		cam = GetComponent<Camera> ();
	}
	void Update()
	{
		if(GameManager.GM.Score >= neededScore )
		{
			ChangeColor ();
		}
	}
	void ChangeColor()
	{
		myColor = mat.color;

		int index = Random.Range (0, colors.Length);

		StartCoroutine (ChangeColors (myColor, colors [index], time));
	}


	IEnumerator ChangeColors(Color source, Color target, float overTime)
	{
		neededScore = neededScore + 50;

		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
			mat.color = Color.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		mat.color = target;
	}
}
