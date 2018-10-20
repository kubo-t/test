using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {

	GameObject text;

	GameObject fire;

	GameObject bomb;

	[SerializeField] public List<GameObject> lineObjects = new List<GameObject>();

	private bool gameClear = false;

	private bool exploaded = false;

	// Use this for initialization
	void Start () {

		text = GameObject.Find ("ClearText");
		fire = GameObject.Find ("Fire");
		bomb = GameObject.Find ("Bomb");

	}


	
	// Update is called once per frame
	void Update () {
		//Debug.Log (lineObjects.Count);
		if(gameClear == true){

			int recentPositionNum = lineObjects.Count - 1;

			if(recentPositionNum  >= 0){

				if(lineObjects[recentPositionNum].gameObject.tag == "LineMaker"){
					lineObjects [recentPositionNum].GetComponent<LineCtrl> ().DestroyPositions ();// 導火線の本線を短くする

					if (lineObjects [recentPositionNum].GetComponent<LineCtrl> ().lineRenderer.positionCount - 1 > 0) { // 導火線のFireオブジェクトを動かす（汚い）
						fire.transform.position = lineObjects [recentPositionNum].GetComponent<LineCtrl> ().lineRenderer.GetPosition (lineObjects [recentPositionNum].GetComponent<LineCtrl> ().lineRenderer.positionCount - 1);
					}else if(lineObjects [0].GetComponent<LineCtrl> ().lineRenderer.positionCount - 1 == 0 && exploaded == false){
						Debug.Log ("LAST");
						fire.transform.position = new Vector3(0f, 1.5f, 0f);
						bomb.GetComponent<BombCtrl> ().Exploasion ();
						exploaded = true;
					}

					if (lineObjects [recentPositionNum].GetComponent<LineCtrl> ().newPositionCount - lineObjects [recentPositionNum].GetComponent<LineCtrl> ().Num == 0) { // 長さ0のLineRendererを持つLineMakerをListから除く
						lineObjects.RemoveAt (recentPositionNum);
					}

				}else if(lineObjects[recentPositionNum].gameObject.tag == "StringMaker"){
					lineObjects [recentPositionNum].GetComponent<StringCtrl> ().DestroyPositions ();// 導火線の本線を短くする

					if(lineObjects[recentPositionNum].GetComponent<StringCtrl>().lineRenderer.positionCount - 1 > 0){
						fire.transform.position = lineObjects [recentPositionNum].GetComponent<StringCtrl> ().lineRenderer.GetPosition (lineObjects[recentPositionNum].GetComponent<StringCtrl>().lineRenderer.positionCount - 1 );
					}

					if(lineObjects[recentPositionNum].GetComponent<StringCtrl>().Num == 3){ // 長さ0のLinerendererを持つStringMakerをListから除く
						lineObjects.RemoveAt (recentPositionNum);
					}
				}
			}



		}
	}

	public void GameClear(){
		text.GetComponent<Text> ().text = "CLEAR!!";

		gameClear = true;
	}
}
