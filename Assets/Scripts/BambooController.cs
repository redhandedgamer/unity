using UnityEngine;
using System.Collections;

public class BambooController : MonoBehaviour {

	public Animator animator;
	public GameObject coin;
	public GameObject bambooMesh;
	public ParticleSystem woodChipper;
	public ParticleSystem deathSmoke;
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

	public void OnTriggerStay(Collider other){

		//enabled emission rate during contact
		woodChipper.emissionRate = 100;
	}
	
	public void OnTriggerExit(Collider other){
		
		woodChipper.emissionRate = 0;
	}


	public IEnumerator DestroyBamboo(float t){

		//waits t seconds chosen in OnTriggerEnter function
		yield return new WaitForSeconds(t);

		//play poof_FX
		deathSmoke.gameObject.SetActive(true);

		//wait for full duration
		yield return new WaitForSeconds(deathSmoke.duration);

		//turn off renderer so object only disappears
		bambooMesh.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(deathSmoke.startLifetime);

		//destroys bamboo
		Destroy(gameObject);

	}
}
