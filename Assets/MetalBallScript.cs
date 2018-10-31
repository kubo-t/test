using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBallScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerCtrl> ().isMetal = true;
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
