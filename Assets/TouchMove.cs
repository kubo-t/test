using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchMove : MonoBehaviour {

	public GameObject player;
	public float speed = 5.0f;
	//public float speedRot = 120.0f;

	//public bool buttonMark = false;

	public bool buttonForward = false;
	public bool buttonBack = false;
	//public bool buttonRight = false;
	//public bool buttonLeft = false;

	//[SerializeField]private LineCtrl lineCtrl;

	SetMarker setMarker;
	GameCtrl gameCtrl;
	StringCtrl stringCtrl;
	LineCtrl lineCtrl;
	Image shotButton;
	Image setMarkButton;

	private int CheckQkey = 0;

	//private bool markLock = false;

	//GameObject[] walls;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerCharactor");
		setMarker = player.GetComponent<SetMarker> ();
		gameCtrl = GameObject.Find ("GameManager").GetComponent<GameCtrl>();
		shotButton = GameObject.Find ("ShotButton").GetComponent<Image> ();
		setMarkButton = GameObject.Find ("SetMarkButton").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(buttonForward)player.transform.position += player.transform.forward * 1.2f * speed * Time.deltaTime;
		if(buttonBack)player.transform.position -= player.transform.forward * 1.2f * speed * Time.deltaTime;

		//Debug.Log (setMarker.markCount);
		if (setMarker.markCount < 3 || gameCtrl.gameClear) {
			shotButton.color = Color.gray;
		//	setMarkButton.color = Color.white;
		} else if(setMarker.markCount == 3){
			shotButton.color = Color.white;
		//	setMarkButton.color = Color.gray;
		}

		if(gameCtrl.gameClear){
			setMarkButton.color = Color.gray;
		}

		//if(buttonRight)player.transform.Rotate (0, speedRot * Time.deltaTime , 0f);
		//if(buttonLeft)player.transform.Rotate (0, - speedRot * Time.deltaTime , 0f);
	}

	public void SetMarkClicked(){

		if(gameCtrl.gameClear){
			return;
		}

		setMarker.Marking ();

		if(gameCtrl.lineObjects[gameCtrl.lineObjects.Count - 1].GetComponent<StringCtrl>()){// StringCtrlを持っているなら
			stringCtrl = gameCtrl.lineObjects [gameCtrl.lineObjects.Count - 1].GetComponent<StringCtrl> ();
			if (CheckQkey == 2) {
				stringCtrl.Qtwo ();
				//stringCtrl.Qkey = 4;
				Debug.Log ("2つ目のアンカー");
			}
			if(stringCtrl.finish == false && CheckQkey == 3){
				stringCtrl.Qfour ();
				Debug.Log ("3つ目のアンカー");
				CheckQkey = 0;
			}
		}

		if(gameCtrl.lineObjects[gameCtrl.lineObjects.Count -1].GetComponent<LineCtrl>()){
			lineCtrl = gameCtrl.lineObjects [gameCtrl.lineObjects.Count - 1].GetComponent<LineCtrl> ();
			if(lineCtrl.positionCount > 1){
				lineCtrl.MakeStringMaker();
			}
		}
	}

	public void ShotButtonClicked(){

		if(shotButton.color == Color.gray){
			return;
		}
			
		GameObject[] stringMaker = GameObject.FindGameObjectsWithTag ("StringMaker"); 
		for(int i = 0; i < stringMaker.Length; i++){
			stringMaker [i].GetComponent<StringCtrl> ().Estring();
		}

		//if (gameCtrl.lineObjects [gameCtrl.lineObjects.Count - 2].GetComponent<StringCtrl> ()) {
		//	Debug.Log ("StringControll");
		//	stringCtrl = gameCtrl.lineObjects [gameCtrl.lineObjects.Count - 2].GetComponent<StringCtrl> ();
		//	stringCtrl.Estring ();
		//}

		GameObject[] pins = GameObject.FindGameObjectsWithTag ("Pin");
		for(int i = 0; i < pins.Length; i++){
			pins [i].GetComponent<MarkPrefab> ().DestroyMarkPrefab ();
		}

		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Wall");
		for(int i = 0; i < walls.Length; i++){
			walls [i].GetComponent<WallScriot> ().WallAddForce ();
			Debug.Log ("WallAddForce");
		}
		/*foreach(GameObject wall in walls){
			wall.GetComponent<WallScriot> ().WallAddForce ();
			Debug.Log ("Shot!!!!");
		}
		*/
		setMarker.MarkClear ();
	}
		
	public void SetMarkButtonUp(){

		if(gameCtrl.gameClear == true ){
			return;
		}

		//buttonMark = false;
		CheckQkey += 1;

		if(setMarker.markCount == 3){
			setMarker.ResetMark ();
		
		}
	}

	public void ForwarButtonDown(){
		//player.transform.position += transform.forward * speed * Time.deltaTime;
		buttonForward = true;
	}
	public void BackButtonDown(){
		//player.transform.position -= transform.forward * speed * Time.deltaTime;
		buttonBack = true;
	}
	/*
	public void RightButtonDown(){
		//player.transform.Rotate (0, speedRot * Time.deltaTime , 0f);
		buttonRight = true;
	}
	public void LeftButtonDown(){
		//player.transform.Rotate (0, - speedRot * Time.deltaTime , 0f);
		buttonLeft = true;
	}
	*/
	public void ForwarButtonUp(){
		//player.transform.position += transform.forward * speed * Time.deltaTime;
		buttonForward = false;
	}
	public void BackButtonUp(){
		//player.transform.position -= transform.forward * speed * Time.deltaTime;
		buttonBack = false;
	}
	/*
	public void RightButtonUp(){
		//player.transform.Rotate (0, speedRot * Time.deltaTime , 0f);
		buttonRight = false;
	}
	public void LeftButtonUp(){
		//player.transform.Rotate (0, - speedRot * Time.deltaTime , 0f);
		buttonLeft = false;
	}
	*/
}
