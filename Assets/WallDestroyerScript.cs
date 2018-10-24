using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E)){
			Destroy (this.gameObject, 2f);
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Wall") {
			Destroy (this.gameObject);
			Destroy (other.gameObject);
		}
	}
}
