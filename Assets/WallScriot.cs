using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScriot : MonoBehaviour {

	[SerializeField] private float wallForce;

	// Use this for initialization
	void Start () {
		
	}

	public void WallAddForce(){
		this.GetComponent<Rigidbody> ().AddForce (this.transform.forward * wallForce);
	}



	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag != "Field"){
			other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * wallForce);
			//other.gameObject.GetComponent<Rigidbody> ().AddForce (this.transform.forward * wallForce/30);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			this.gameObject.AddComponent<BoxCollider> ();
			WallAddForce ();
			Destroy (this.gameObject, 2f);
		}
	}
}
