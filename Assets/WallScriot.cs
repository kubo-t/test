using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScriot : MonoBehaviour {

	[SerializeField] private float wallForce;

	private float timepower = 1f; //時間に応じた係数　長い距離で弾くほどパワーが出るように
	private float timepower2 = 1f;

	private bool Ekey = false;

	[SerializeField] float totalForce;

	// Use this for initialization
	void Start () {
		
	}

	public void WallAddForce(){
		this.GetComponent<Rigidbody> ().AddForce (this.transform.forward * totalForce);
	}



	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag != "Field"){
			other.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * wallForce/4 * timepower2);
			Debug.Log (wallForce/4 * timepower2);
			if (Ekey)Ekey = false;
			//other.gameObject.GetComponent<Rigidbody> ().AddForce (this.transform.forward * wallForce/30);
		}
		if(other.gameObject.tag == "Player"){
			Destroy (this.gameObject);

			if (Ekey)Ekey = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			this.gameObject.AddComponent<BoxCollider> ();
			WallAddForce ();
			Destroy (this.gameObject, 2f);

			if (!Ekey)Ekey = true;
		}

		if(Ekey){
			timepower += 1 * Time.deltaTime;
			timepower2 += timepower * 10 * Time.deltaTime; //上向きの力
		}

		totalForce = wallForce * timepower;
		//Debug.Log (timepower);
		//Debug.Log (totalForce);
	}
}
