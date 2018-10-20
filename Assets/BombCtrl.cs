using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCtrl : MonoBehaviour {

	public GameObject bomb;
	public GameObject bombPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exploasion(){
		Destroy (this.gameObject);
		Instantiate(bomb, bombPos.transform.position, Quaternion.identity);
	}
}
