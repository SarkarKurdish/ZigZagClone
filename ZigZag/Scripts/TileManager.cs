using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	
	[Header("Dimons")]
	public int maximuimChance = 100; // max chance to get a dmond

	[Header("TileSpawn")]
	public int TileSpawnCount; // how many tile should be spawn at Start of the game and in runtime ?
	public GameObject currentTile;
	public GameObject[] tilsToSpawn ; // First one is leftTile , second one is top  tile //

	[HideInInspector]
	public List<GameObject> tils = new List<GameObject>();

	#region Singltion

	[HideInInspector]
	public static TileManager tileManager;

	void Awake(){
		if(tileManager == null)
		{
			tileManager = this;
		}else{
			Destroy (gameObject);
		}
	}
	#endregion

	void Update()
	{

		if(tils.Count<=40)
		{
			SpawnTile ();
		}
	}

	void Start () {
		SpawnTile ();
	}

	void SpawnTile ()
	{
		for (int i = 0; i < 50; i++) {
			int index = Random.Range (1,3);
			int dimondIndex = Random.Range(0,maximuimChance);

			if(index == 1){
			GameObject spawnedTile = Instantiate (tilsToSpawn [0], currentTile.transform.GetChild (0).transform.GetChild (1).position, Quaternion.identity);
			currentTile = spawnedTile;
				tils.Add (spawnedTile);
				if(dimondIndex == 1)
				{
					spawnedTile.transform.GetChild (1).gameObject.SetActive (true);
				}
			}

			else if(index == 2)
				
			{
				GameObject spawnedTile = Instantiate (tilsToSpawn [1], currentTile.transform.GetChild (0).transform.GetChild (0).position, Quaternion.identity);
				currentTile = spawnedTile;
				tils.Add (spawnedTile);
				if(dimondIndex == 1)
				{
					spawnedTile.transform.GetChild (1).gameObject.SetActive (true);
				}
			}
		}
	}
}
