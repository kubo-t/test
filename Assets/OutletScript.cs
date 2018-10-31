using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletScript : MonoBehaviour {

	private bool onSwitch = false;

	[SerializeField]private GameObject elevator;
	//private Animator elevanim;

	// Use this for initialization
	void Start () {
		elevator.GetComponent<Animator> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update (){
		if(this.onSwitch){
			elevator.GetComponent<Animator> ().enabled = true;
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			if(other.gameObject.GetComponent<PlayerCtrl>().isElectric ){
				other.gameObject.GetComponent<PlayerCtrl> ().isElectric = false;
				this.onSwitch = true;
			}
		}
	}
}
