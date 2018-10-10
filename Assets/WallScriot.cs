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
		other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * wallForce/5);
		other.gameObject.GetComponent<Rigidbody> ().AddForce (this.transform.forward * wallForce/5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
