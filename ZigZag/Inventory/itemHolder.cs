using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemHolder : MonoBehaviour {
	public Text costText;
	private Color spriteColor;
	public Image image;
	private Sprite mySprite;
	private int cost;
	public Material itemMaterial;

	public bool alreadyBought;

	float r;
	float b;
	float g;

	GameObject target;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		if(PlayerPrefs.GetInt("alreadyBought"+gameObject.name) == 2)
		{
			alreadyBought = true;
		}else{
			alreadyBought = false;
		}
	}


	public void UpdateHolder(Sprite sprite, int _cost , Color _spriteColor ,Material _itemMaterial)
	{
		mySprite = sprite;
		image.sprite = mySprite;
		image.color = _spriteColor;
		cost = _cost;
		costText.text = cost.ToString ();
		itemMaterial = _itemMaterial;
	}

	public void  Update()
	{
		if (mySprite == null)
			return;
		
		if (target.GetComponent<Renderer> ().material.color == itemMaterial.color && alreadyBought) {
			costText.text = "Used";
			PlayerPrefs.SetFloat ("r" , itemMaterial.color.r );
			PlayerPrefs.SetFloat ("b" , itemMaterial.color.b );
			PlayerPrefs.SetFloat ( "g" , itemMaterial.color.g);

		}else if(alreadyBought &&target.GetComponent<Renderer> ().material.color != itemMaterial.color){
			
			costText.text = "Use";

		}else if(!alreadyBought){
			
			costText.text = cost.ToString ();

		}
	}
	public void Buy()
	{
		if (mySprite == null)
			return;
		
			
		GameManager manager = GameManager.GM;

		if (manager.dimond >= cost && !alreadyBought)
		{
			target.GetComponent<Renderer> ().material = itemMaterial;
			manager.dimond -= cost;
			PlayerPrefs.SetInt ("alreadyBought"+gameObject.name, 2);
			alreadyBought = true;
			costText.text = "Use";
		}else if (alreadyBought)
		{
			target.GetComponent<Renderer> ().material = itemMaterial;
		}
			
	}


}
