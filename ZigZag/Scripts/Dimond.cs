using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimond : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			StartCoroutine ("colied");
		}
	}

	IEnumerator colied()
	{
		GameManager.GM.GetDimond (1);
		GetComponent<MeshRenderer> ().enabled = false;
		transform.GetChild (0).gameObject.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}
}
