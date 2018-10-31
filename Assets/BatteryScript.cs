using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			if (other.gameObject.GetComponent<PlayerCtrl> ().isMetal) {

				other.gameObject.GetComponent<PlayerCtrl> ().isElectric = true;

			}
			//Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
