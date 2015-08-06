using UnityEngine;
using System.Collections;

public class DestroyByLifeTime : MonoBehaviour {

	public float lifetime;

	void Start() {
		Destroy(gameObject, lifetime);
	}
}
