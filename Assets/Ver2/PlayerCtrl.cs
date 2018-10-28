using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
//using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {

	public float speed = 5.0f; //プレイヤーの移動速度
	public float speedRot = 120.0f; //プレイヤーの回転速度

	public GameObject gameManager;

	public GameObject firstLineMaker;

	//Text text;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		GameObject LineMaker = Instantiate (firstLineMaker, this.transform.position, Quaternion.identity);
		LineMaker.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = CrossPlatformInputManager.GetAxis ("Mouse X");
		this.transform.Rotate (0, horizontal * speedRot * 2.1f * Time.deltaTime , 0f);

		PlayerMove ();
		//text = GameObject.Find ("Text");
	}

	public void PlayerMove(){
		if(Input.GetKey(KeyCode.W)){
			this.transform.position += transform.forward * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)){
			this.transform.Rotate (0, - speedRot * Time.deltaTime , 0f);
		}
		if(Input.GetKey(KeyCode.S)){
			this.transform.position -= transform.forward * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D)){
			this.transform.Rotate (0, speedRot * Time.deltaTime, 0f);
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Goal"){
			gameManager.GetComponent<GameCtrl> ().GameClear ();
		}
	}
}
