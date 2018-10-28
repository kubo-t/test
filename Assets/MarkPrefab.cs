using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keycode E

public class MarkPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			DestroyMarkPrefab();
		}
	}

	public void DestroyMarkPrefab(){
		Destroy (this.gameObject);
	}
}
