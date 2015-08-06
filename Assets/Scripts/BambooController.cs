using UnityEngine;
using System.Collections;

public class BambooController : MonoBehaviour {

	public Animator animator;
	public GameObject coin;
	//public GameObject bambooMesh;
	public GameObject smokeFX;
	public ParticleSystem woodChipFX;
	public ParticleSystem leavesFX;
	public Transform smokeSpawn;
	public Transform coinSpawn;
	public float destroyTime = 1.5f;
	public int scoreValue;
	private GameController gameController;

	//find gameObject that holds gameController script, check for exist
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController>();
		if(gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	//play this Trigger from Bamboo Animator
	public void PlayChopEvent(){
		animator.SetTrigger("Chop");

	}

	public void OnTriggerEnter(Collider other){

		//play animation
		PlayChopEvent();

		//run Coroutine to destroy bamboo instance after given time
		StartCoroutine(DestroyBamboo(destroyTime));

		//spawn coin
		Instantiate(coin, coinSpawn.position, coinSpawn.rotation);

		//increase score
		gameController.AddScore(scoreValue);

	}

	public void OnTriggerStay(Collider other){

		//enabled emission rate while Ninja Star is colliding
		woodChipFX.emissionRate = 200;
		leavesFX.emissionRate = 200;
	}
	
	public void OnTriggerExit(Collider other){

		//disables emission rate after Ninja Star leaves collider
		woodChipFX.emissionRate = 0;
		leavesFX.emissionRate = 0;

		//delete the Collider to prevent multiple triggers of this function on same prefab
		Destroy(GetComponent<Collider>());

	}

	public IEnumerator DestroyBamboo(float t){

		//waits t seconds chosen in OnTriggerEnter function
		yield return new WaitForSeconds(t);

		//play poof_FX
		Instantiate(smokeFX, smokeSpawn.position, smokeSpawn.rotation);

		//destroys bamboo
		Destroy(gameObject);

	}
}
