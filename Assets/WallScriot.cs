using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keycode E

public class WallScriot : MonoBehaviour {

	[SerializeField] private float wallForce;

	private float timepower = 1f; //時間に応じた係数　長い距離で弾くほどパワーが出るように
	private float timepower2 = 1f;

	private float wallForceOffset = 0f;

	private bool Ekey = false;

	[SerializeField] float totalForce;

	// Use this for initialization
	void Start () {
		
	}

	public void WallAddForce(){
		this.gameObject.AddComponent<BoxCollider> ();
		this.GetComponent<Rigidbody> ().AddForce (this.transform.forward * totalForce);
		Destroy (this.gameObject, 2f);
		if (!Ekey)Ekey = true;
	}



	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag != "Field"){
			if (wallForce / 4 * (timepower2 * 4/5) < 900f) {
				other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * wallForce/1.8f * (timepower2 * 4/5));
			} else {
				other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 900);
			}
			Debug.Log (wallForce/4 * (timepower2 * 4/5));
			Debug.Log (wallForceOffset);
			if (Ekey)Ekey = false;
			//other.gameObject.GetComponent<Rigidbody> ().AddForce (this.transform.forward * wallForce/30);
		}
		if(other.gameObject.tag == "Player"){
			Destroy (this.gameObject);

			if (Ekey)Ekey = false;
		}
		if(other.gameObject.tag == "Car"){
			other.gameObject.GetComponent<Rigidbody> ().AddForce ((this.transform.forward * wallForce * timepower2) * 2);
			Destroy (this.gameObject);
			Debug.Log ("aaa");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			//this.gameObject.AddComponent<BoxCollider> ();
			WallAddForce ();
			//Destroy (this.gameObject, 2f);

			//if (!Ekey)Ekey = true;
		}

		if(Ekey){
			timepower += 1 * Time.deltaTime;
			timepower2 += timepower * timepower * 10 * Time.deltaTime; //上向きの力
			wallForceOffset += 500f * Time.deltaTime;
		}

		totalForce = (wallForce * timepower) + wallForceOffset;
		//Debug.Log (timepower);
		//Debug.Log (totalForce);
	}
}
