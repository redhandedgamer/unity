using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	public enum TurnDirection {
		Left = -1,
		Right = 1
	}
	public bool useRigidbody = false;
	public float speed;

	public TurnDirection turnDirection = TurnDirection.Left;
	public float torque;
	private Rigidbody rigidbody;

	void Start(){
		if(useRigidbody){
			rigidbody = GetComponent<Rigidbody>();
			rigidbody.AddTorque(transform.up * torque * (int)turnDirection);
		}
	}

	void Update(){
		if(!useRigidbody)
			transform.Rotate(transform.up * speed * Time.deltaTime * (int)turnDirection);
	}
}
