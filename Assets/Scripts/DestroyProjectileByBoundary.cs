using UnityEngine;
using System.Collections;

public class DestroyProjectileByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other){

		if(other.tag == "Bamboo")
			return;

		Debug.Log("Destroyed this object: " + other.gameObject);
		Destroy(other.gameObject);

	}
}
