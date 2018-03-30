using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public float daily;
	public float force;
	public float timeBeforeInactive;


	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag != "Player")
			return;
		
		StartCoroutine (Falling ());

	}

	IEnumerator Falling()
	{
		yield return new WaitForSeconds (daily);
		GetComponent<Rigidbody> ().isKinematic = false; // let Object Fall Down

		GetComponent<Rigidbody> ().AddForce (Vector2.down * force * Time.deltaTime);// add him some force to Down

		GameObject parent = transform.parent.gameObject; // make sure we have control of intire Object

		yield return new WaitForSeconds (timeBeforeInactive); // let Object fall down and disappear in camera then make it inActive then send to polling

		TileManager.tileManager.tils.Remove (parent);

		Destroy (parent.gameObject);

	
	}

/*	void SpawnTile (int index , TileManager tilemanger)
	{
		int dimondIndex = Random.Range(0,TileManager.tileManager.maximuimChance);
		print (dimondIndex);

		GameObject currentTile = TileManager.tileManager.currentTile;

		if (index == 0) {
			GameObject spawnedTile = Instantiate (tilemanger.tilsToSpawn [0], currentTile.transform.GetChild (0).transform.GetChild (1).position, Quaternion.identity);
			spawnedTile.transform.GetChild(0).GetComponent<Tile> ().myType = 0;
			TileManager.tileManager.currentTile = spawnedTile;

			if(dimondIndex == 1)
			{
				spawnedTile.transform.GetChild (1).gameObject.SetActive (true);
			}


		} else if (index == 1) {
			
			GameObject spawnedTile = Instantiate (tilemanger.tilsToSpawn [1], currentTile.transform.GetChild (0).transform.GetChild (0).position, Quaternion.identity);
			spawnedTile.transform.GetChild(0).GetComponent<Tile> ().myType = 0;
			TileManager.tileManager.currentTile = spawnedTile;

			if(dimondIndex == 1)
			{
				spawnedTile.transform.GetChild (1).gameObject.SetActive (true);
			}
		}
	}*/
}
