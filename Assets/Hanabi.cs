using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanabi : MonoBehaviour {

	[SerializeField]private GameObject otimono;

	Rigidbody otimonoBody;

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "WildFire"){
			otimonoBody.useGravity = true;
			otimonoBody.isKinematic = false;

			Debug.Log ("WildFire");
		}


	}

	// Use this for initialization
	void Start () {
		otimonoBody = otimono.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
