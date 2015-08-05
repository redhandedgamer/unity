using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject bamboo;
	public Vector3 spawnValues;
	public int bambooCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// call spawn bamboo on first frame
	void Start(){

		StartCoroutine(SpawnBamboo());
	}

	IEnumerator SpawnBamboo(){

		yield return new WaitForSeconds(startWait);

		while(true){

			for(int i = 0; i < bambooCount; i++){
				Vector3 spawnPosition = new Vector3(Random.Range
				                                   (-spawnValues.x, spawnValues.x),
				                                    spawnValues.y,
				                                    spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(bamboo, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);

		}
	}
}
