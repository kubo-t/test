using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {

	[SerializeField]private GameObject yuka;
	[SerializeField]private GameObject anayuka;

	Renderer renderer_yuka;
	Renderer renderer_ana;
	BoxCollider col_yuka;
	MeshCollider col_ana;

	GameObject text;

	GameObject fire;

	GameObject bomb;

	Light holeLight;

	[SerializeField] public List<GameObject> lineObjects = new List<GameObject>();

	public bool gameClear = false;

	private bool exploaded = false;

	// Use this for initialization
	void Start () {

		renderer_yuka = yuka.GetComponent<Renderer> ();
		renderer_ana = anayuka.GetComponent<Renderer> ();
		col_yuka = yuka.GetComponent<BoxCollider> ();
		col_ana = anayuka.GetComponent<MeshCollider> ();

		renderer_yuka.enabled = true;
		renderer_ana.enabled = false;
		col_yuka.enabled = true;
		col_ana.enabled = false;

		text = GameObject.Find ("ClearText");
		fire = GameObject.Find ("Fire");
		bomb = GameObject.Find ("Bomb");

		holeLight = GameObject.Find ("HoleLight").GetComponent<Light> ();
		holeLight.intensity = 0;
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
						fire.transform.position = lineObjects [recentPositionNum].GetComponent<LineCtrl> ().lineRenderer.GetPosition (lineObjects [recentPositionNum].GetComponent<LineCtrl> ().lineRenderer.positionCount - 2);
					}else if(lineObjects [0].GetComponent<LineCtrl> ().lineRenderer.positionCount - 1 == 0 && exploaded == false){ //爆発する瞬間
						Debug.Log ("LAST");
						fire.transform.position = new Vector3(0f, 1.5f, 0f);
						bomb.GetComponent<BombCtrl> ().Exploasion ();
						exploaded = true;

						renderer_yuka.enabled = false;
						renderer_ana.enabled = true;
						col_yuka.enabled = false;
						col_ana.enabled = true;
						holeLight.intensity = 8;
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
