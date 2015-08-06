using UnityEngine;
using System.Collections;

public class AnimateBambooByContact : MonoBehaviour {

	public Animator animator;
	public GameObject coin;
	public Transform coinSpawn;
	public float destroyTime = 1.5f;

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


	}

	public IEnumerator DestroyBamboo(float t){

		//waits t seconds chosen in OnTriggerEnter function
		yield return new WaitForSeconds(t);

		//destroys bamboo
		Destroy(gameObject);

	}
}
