using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

	[SerializeField]private float JumpPower;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			Debug.Log ("Jump");
			other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * JumpPower);
			Debug.Log (other.name);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
