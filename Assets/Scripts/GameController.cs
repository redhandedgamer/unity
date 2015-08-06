using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject bamboo;
	public Vector3 spawnValues;
	public int bambooCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText;
	private int score;

	public Text waveCountText;
	private int waveCount;

	void Start(){

		//initial UI variable and text setup
		score = 0;
		waveCount = 0;
		UpdateScore();
		UpdateWaveCount();

		//call spawn bamboo on first frame
		StartCoroutine(SpawnBamboo());
	}

	void UpdateScore(){
		scoreText.text = "Coins Collected: " + score;
	}

	void UpdateWaveCount(){
		waveCountText.text = "Waves Completed: " + waveCount;
	}

	IEnumerator SpawnBamboo(){

		//waits this many seconds before starting to spawn the bamboo
		yield return new WaitForSeconds(startWait);

		while(true){

			for(int i = 0; i < bambooCount; i++){

				//spawns bamboo prefabs in a grid on the X and Z axes
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),
				                                    0.0f,
				                                    Random.Range(-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(bamboo, spawnPosition, spawnRotation);

				Debug.Log("Bamboos Spawned: " + i);

				//waits to spawn next prefab
				yield return new WaitForSeconds(spawnWait);
			}

			//waits to spawn next wave of bamboo
			yield return new WaitForSeconds(waveWait);
			
			//tracks wave number
			waveCount++;
			UpdateWaveCount();

		}
	}

	//public function to talk to bambooController
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}
}
