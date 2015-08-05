using UnityEngine;
using System.Collections;

public class DestroyBambooByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		//Debug.Log("GAHHHHHHHHH");

		if(other.tag == "Boundary")
			return;

		Debug.Log("Destroyed this object: " + other.gameObject);
		Destroy(other.gameObject);

	}
}
