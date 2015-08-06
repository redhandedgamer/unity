using UnityEngine;
using System.Collections;

[System.Serializable]
public class Bounds{

	public float zMin, zMax;

}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Bounds bounds;

	public GameObject shot;
	public Transform shotSpawn;

	public float shotRate;
	private float nextShot;

	void Update(){
		if(Input.GetButton("Fire1") && Time.time > nextShot){
			nextShot = Time.time + shotRate;
			GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		}
	}

	void FixedUpdate(){

		//left & right movement variable
		float moveHorizontal = Input.GetAxis("Horizontal");

		//movement code for Player rigidbody
		Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);
		GetComponent<Rigidbody>().velocity = movement * speed;

		//clamping movement in game space
		GetComponent<Rigidbody>().position = new Vector3
		(
			8.6f,
			1.3f,
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, bounds.zMin, bounds.zMax)
		);
	}
}
