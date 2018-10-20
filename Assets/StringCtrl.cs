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

	private Vector3[] stringPositions = new Vector3[3];

	private float d = 0f;
	public int Num = 0;

	GameObject gameManager;

	private bool activeUpdate = true; //クリアいたらupdateを止める


	// Use this for initialization
	void Start () { //Qキー1回目

		gameManager = GameObject.Find ("GameManager");
		gameManager.GetComponent<GameCtrl> ().lineObjects.Add (this.gameObject);

		this.transform.rotation = Quaternion.Euler(90f, 0f,0f);

		player = gameObject.transform.parent.gameObject;
		lineRenderer = this.GetComponent<LineRenderer> ();

		lineRenderer.enabled = false; //Qキを押した瞬間、原点から現在地に線が引かれてしまう　防ぎ方がわからないため一瞬だけLineRendereを非表示にする

		lineRenderer.SetVertexCount (PosNum);
		stringPositions [0] = this.transform.position;
		lineRenderer.SetPosition (0, stringPositions[0]);
		Debug.Log ("1つ目のアンカー");
		lineRenderer.numCornerVertices = 10; //角をなめらかにする度合い
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

				finish = true;
			}
		}
			
		if (Input.GetKeyUp (KeyCode.E)) {

			if(finish == false){ // 3点押される前のEキー：フニャフニャ線を生成する
				GameObject LineMaker = Instantiate (lineMakerPrefab, player.transform.position, Quaternion.identity);
				LineMaker.transform.parent = this.player.transform;
			}

			if(finish == true){ // 3点押された後のEキー：糸をまっすぐ伸ばす
			stringPositions [1] = new Vector3 ((stringPositions[0].x + stringPositions[2].x) /2, (stringPositions[0].y + stringPositions[2].y) /2, (stringPositions[0].z + stringPositions[2].z) /2);
			lineRenderer.SetPosition (1, stringPositions [1]);
			}

			//Destroy (this); //その後消える
				activeUpdate = false;
		}
		}
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
