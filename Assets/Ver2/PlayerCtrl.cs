using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

	public float speed = 5.0f; //プレイヤーの移動速度
	public float speedRot = 120.0f; //プレイヤーの回転速度

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
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
}
