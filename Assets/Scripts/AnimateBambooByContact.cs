using UnityEngine;
using System.Collections;

public class AnimateBambooByContact : MonoBehaviour {

	public Animator animator;

	// play this Trigger from Bamboo Animator
	public void PlayChopEvent(){
		animator.SetTrigger("Chop");

	}

	public void OnTriggerEnter(Collider other){

		//play animation
		PlayChopEvent();


		StartCoroutine(DestroyBamboo(1.5f));

		//play VFX


	}

	public IEnumerator DestroyBamboo(float t){

		yield return new WaitForSeconds(t);

		Destroy(gameObject);

	}


	void Update(){



	}

}
