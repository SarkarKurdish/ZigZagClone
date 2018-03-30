using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour {

	#region Singlton
	public static dontDestroyOnLoad d;
	void Awake () {
		if (d == null) {
			d = this;
		} else{
			Destroy (gameObject);
		}
	}
	#endregion

	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}
}
