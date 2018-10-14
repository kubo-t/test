using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCtrl : MonoBehaviour {

	GameObject player;

	private float step = 0f;
	private float speedStep = 3.5f;

	//private bool synchro = false;

	// Use this for initialization
	void Start () {
		player = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		TrailMove ();
	}

	public void TrailMove(){

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			this.transform.position = player.transform.position;
		}

		if(Input.GetKey(KeyCode.W)){
			step += 1 * Time.deltaTime;

			float randomize = Random.Range (-0.5f, 0.5f);

			if (step <= 0.2f) {
				this.transform.position += player.transform.right * (speedStep + randomize) * Mathf.Sin(Time.deltaTime);
			}else if(step > 0.2f && step < 0.4f){
				this.transform.position -= player.transform.right * (speedStep + randomize) * Mathf.Sin(Time.deltaTime);
			}else if(step >= 0.4f){
				this.transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y, player.transform.position.z);
				Debug.Log ("同期しました");
				step = 0f;
			}
				
		}

		if (Input.GetKey (KeyCode.Space)) {
			this.GetComponent<TrailRenderer> ().time = 5f;
		}
	}

}
