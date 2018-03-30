using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public BallTypes[] ballType;
	private itemHolder[] holder;

	public Transform holderParent;

	void Start()
	{
		holder = holderParent.GetComponentsInChildren<itemHolder> ();

		for (int i = 0; i < ballType.Length; i++) {
			if (ballType [i] == null)
				return;
				holder [i].UpdateHolder (ballType [i].sprite, ballType [i].cost , ballType[i].spriteColor , ballType[i].itemMaterial);

		}
	}

}
