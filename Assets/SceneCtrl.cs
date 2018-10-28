using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			Invoke ("SceneChange", 1f);
			Debug.Log ("SceneMoved");
		}

	}

	void SceneChange(){
		SceneManager.LoadScene ("Stage3");
	}
}
