using UnityEngine;
using System.Collections;

public class AnimateCoin : MonoBehaviour {
	
	public Animator animator;
	
	//play this Trigger from Coin Animator
	public void PlaySpinEvent(){
		animator.SetTrigger("Spin");
		
	}
	
	public void OnTriggerEnter(Collider other){
		
		//play animation
		PlaySpinEvent();
		
		//run Coroutine to destroy coin instance after given time
		StartCoroutine(DestroyCoin(1.5f));
		
		//play VFX
		
		
	}
	
	public IEnumerator DestroyCoin(float t){
		
		//waits t seconds chosen in OnTriggerEnter function
		yield return new WaitForSeconds(t);
		
		//destroys coin
		Destroy(gameObject);
		
	}
}
