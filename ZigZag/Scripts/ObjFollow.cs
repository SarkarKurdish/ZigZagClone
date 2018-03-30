using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollow : MonoBehaviour {

	GameObject target;
	public Vector3 offset;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate () {
		transform.position = target.transform.position + offset;
	}
}
