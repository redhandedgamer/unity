using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject bamboo;
	public Vector3 spawnValues;
	public int bambooCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//call spawn bamboo on first frame
	void Start(){
		StartCoroutine(SpawnBamboo());
	}

	IEnumerator SpawnBamboo(){

		//waits this many seconds before starting to spawn the bamboo
		yield return new WaitForSeconds(startWait);

		while(true){

			for(int i = 0; i < bambooCount; i++){
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, 0.0f),
				                                    0.0f,
				                                    Random.Range(-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(bamboo, spawnPosition, spawnRotation);

				//waits to spawn
				yield return new WaitForSeconds(spawnWait);
			}

			//waits to spawn next wave of bamboo
			yield return new WaitForSeconds(waveWait);

		}
	}
}
