using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringCtrl : MonoBehaviour {

	/*///////////////////////スクリプト概要///////////////////////////////

	生成時・Qキー（1回目）・Qキー（2回目）の3点にピンと糸が張るようにする
	GetKeyDownで回数を管理すると一気に複数回押されたことになってしまうためQkey変数で管理
	Qキーを上げるとカウントが進むようにした

	終了時(Qキーが3回押されたら)LineMakerを生成
	
	 ///////////////////////////////////////////////////////////////////*/


	private int PosNum = 2;
	private int Qkey = 1;
	private bool finish = false;

	GameObject player; // プレイヤーキャラ

	public LineRenderer lineRenderer; // LineRenderer

	[SerializeField] private GameObject lineMakerPrefab; // Qキーで弦のPrefabを生成するために取得

	public Vector3[] stringPositions = new Vector3[3];

	private float d = 0f;
	public int Num = 0;

	GameObject gameManager;

	private bool activeUpdate = true; //クリアしたらupdateを止める

	private bool LeapStart = false; // lerp用
	[SerializeField] private GameObject walldestroyer;
	private int walldestroyernum;


	// Use this for initialization
	void Start () { //Qキー1回目

		gameManager = GameObject.Find ("GameManager");
		gameManager.GetComponent<GameCtrl> ().lineObjects.Add (this.gameObject);

		this.transform.rotation = Quaternion.Euler(90f, 0f,0f);

		player = gameObject.transform.parent.gameObject;
		lineRenderer = this.GetComponent<LineRenderer> ();

		lineRenderer.enabled = false; //Qキーを押した瞬間、原点から現在地に線が引かれてしまう（1f更新を待つため）　防ぎ方がわからないため一瞬だけLineRendereを非表示にする

		lineRenderer.SetVertexCount (PosNum);
		stringPositions [0] = this.transform.position;
		lineRenderer.SetPosition (0, stringPositions[0]);
		Debug.Log ("1つ目のアンカー");
		//lineRenderer.numCornerVertices = 1; //角をなめらかにする度合い

		walldestroyernum = GameObject.Find ("PlayerCharactor").GetComponent<SetMarker> ().wallDestroyerNum;
	}
	
	// Update is called once per frame
	void Update () {

		if(activeUpdate == true){

		if(lineRenderer.enabled == false) lineRenderer.enabled = true; //LineRendererが非表示なら表示に

		if(Qkey == 1){
			if (Input.GetKeyUp (KeyCode.Q)) {
				Qkey = 2;
			}
		}

		if(Qkey == 2){ // Qキー2回目
			if(Input.GetKeyDown(KeyCode.Q)){
				PosNum = 3;
				lineRenderer.SetVertexCount (PosNum);
				stringPositions [1] = this.transform.position;
				lineRenderer.SetPosition (PosNum - 2, stringPositions [1]);

				Debug.Log ("2つ目のアンカー");

				Qkey = 3;

			}
		}

		if(Qkey == 3){ // Qキー2回目
			if(Input.GetKeyUp(KeyCode.Q)){

				Qkey = 4;

			}
		}

		if(finish == false){
			lineRenderer.SetPosition (PosNum - 1, this.transform.position);
		}

		if (Qkey == 4 && finish == false) { //Qキー3回目

			if(Input.GetKeyDown(KeyCode.Q)){
				//lineRenderer.SetVertexCount (PosNum);

				stringPositions [2] = this.transform.position;
				lineRenderer.SetPosition (PosNum - 1, stringPositions [2]);

				GameObject LineMaker = Instantiate (lineMakerPrefab, player.transform.position, Quaternion.identity);
				LineMaker.transform.parent = this.player.transform;

				Debug.Log ("3つ目のアンカー");

					walldestroyer = GameObject.Find ("WallDestroyer" + walldestroyernum);

				finish = true;
			}
		}
			
		if (Input.GetKeyDown (KeyCode.E)) { // Eキーが押されたら 

			if(finish == false){ // 3点押される前のEキー：フニャフニャ線を生成する
				GameObject LineMaker = Instantiate (lineMakerPrefab, player.transform.position, Quaternion.identity);
				LineMaker.transform.parent = this.player.transform;

				//stringPositions [1] = new Vector3 ((stringPositions[0].x + stringPositions[2].x) /2, (stringPositions[0].y + stringPositions[2].y) /2, (stringPositions[0].z + stringPositions[2].z) /2);
				//lineRenderer.SetPosition (1, stringPositions [1]);
			}

			if(finish == true){ // 3点押された後のEキー：糸をまっすぐ伸ばす
			
					//stringPositions [1] = new Vector3 ((stringPositions[0].x + stringPositions[2].x) /2, (stringPositions[0].y + stringPositions[2].y) /2, (stringPositions[0].z + stringPositions[2].z) /2);
					LeapStart = true;

			}

			//Destroy (this); //その後消える
				Invoke("FalseActiveUpdate", 1f);
		}
			if(LeapStart == true){
				stringPositions [1] = Vector3.Lerp (stringPositions[1], new Vector3 ((stringPositions [0].x + stringPositions [2].x) / 2, (stringPositions [0].y + stringPositions [2].y) / 2, (stringPositions [0].z + stringPositions [2].z) / 2), 30f * Time.deltaTime);
				lineRenderer.SetPosition (1, stringPositions [1]);
			}

		}
	}

	void FalseActiveUpdate(){
		activeUpdate = false;
		//Debug.Log ("aa");
	}

	public void DestroyPositions(){

		activeUpdate = false;

		float t = 0.1f;

		d += 1f * Time.deltaTime;
		if (Num <= 2 && d > t) {
			Num += 1;
			//positionCount -= 1;
			lineRenderer.SetVertexCount(3 - Num);
			d = 0f;
		}
	}
}
