using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrl : MonoBehaviour {

	private float step = 0f;
	private float speedStep = 3.5f;

	private float delta = 0f;

	GameObject player;

	LineRenderer lineRenderer;

	private List<Vector3> positionList = new List<Vector3>();
	private int positionCount; //positionListの要素数

	// Use this for initialization
	void Start () {

		player = gameObject.transform.parent.gameObject;
		lineRenderer = this.GetComponent<LineRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		LineMove ();
	}

	void LineMove(){


		delta += 1 * Time.deltaTime;

		if(delta > 0.3f){

			positionCount = positionList.Count;

			positionList.Add (this.transform.position);
			lineRenderer.SetVertexCount (positionCount);

			delta = 0;

		}

		if (positionCount > 0) {
			lineRenderer.SetPosition (positionCount - 1, this.transform.position);
		} else {
			lineRenderer.SetPosition (0, this.transform.position);
		}

		if(delta == 0){

			for(int i = 0; i < positionCount; i++){
				lineRenderer.SetPosition (i, positionList[i]);
			}

		}

		//lineRenderer.SetPosition (0, Vector3.right * -2);
		//lineRenderer.SetPosition (1, Vector3.right * 3);
		//lineRenderer.SetPosition (2, Vector3.right * 6);

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			this.transform.position = player.transform.position;
		}

		if(Input.GetKey(KeyCode.W)){
			step += 1 * Time.deltaTime;

			float randomize = Random.Range (-0.5f, 0.5f);

			if (step <= 0.2f) {
				this.transform.position += player.transform.right * (speedStep + randomize) * Time.deltaTime;
			}else if(step > 0.2f && step < 0.4f){
				this.transform.position -= player.transform.right * (speedStep + randomize) * Time.deltaTime;
			}else if(step >= 0.4f){
				this.transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y, player.transform.position.z);
				Debug.Log ("同期しました");
				step = 0f;
			}

		}


	}


}
