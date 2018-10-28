using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrl : MonoBehaviour {

	/*///////////////////////スクリプト概要///////////////////////////////

	最新の点にプレイヤーキャラの座標を入れている。
	setPositionRate秒ごとの地点でのプレイヤーキャラの座標を入れている。

	常にプレイヤーキャラのお尻から線が伸びるようになっている。

	可能な限り軽くしたいため、setPositionRateは大きめにして、
	荒くなった線を滑らかにすることで誤魔化している。

	--------------------------------------------------------------------------

	LineRendererの仕様上、1つのコンポーネントにつき1つまでしか線を描画できない
	はじめにフニャフニャ線を描画するプレファブ(LineMaker(0))を配置
	　→　1回目のQキーで直線を描画するプレファブ(StringMaker(0))を生成
			→　3回目のQキーでフニャフニャ線を描画するプレファブ(LineMaker(1))を生成　
					→　1回目のQキーで直線を描画するプレファブ(StringMaker(1))を生成
							→　3回目のキーでフニャフニャ線を描画するプレファブ(LineMaker(2))を生成
									→以下略...　
	のループを組む

	終了時(1回目のQキーが押されたら)StringMakerを生成

	 ///////////////////////////////////////////////////////////////////*/

	private float delta = 0f;
	private float setPositionRate = 0.35f; //小さくするほど線がなめらかになり、動作が重くなる
	private bool first = true;

	GameObject player; // プレイヤーキャラ
	private Vector3 startPos;

	public LineRenderer lineRenderer; // LineRenderer

	[SerializeField] private GameObject stringMakerPrefab; // Qキーで弦のPrefabを生成するために取得

	public List<Vector3> positionList = new List<Vector3>(); // Linrendererに格納する座標群
	public int positionCount; //positionListの要素数

	private bool DestroPositions = false;
	private float d = 0f;
	public int Num = 0;

	GameObject gameManager;

	private bool activeUpdate = true; //ゲームクリアしたらupdateを止める

	public int newPositionCount;

	GameObject buttonCtrl;
	TouchMove touchMove;

	[SerializeField]private Material material1;
	[SerializeField]private Material material2;
	//Material[] mats;

	// Use this for initialization
	void Start () {

		gameManager = GameObject.Find ("GameManager");
		gameManager.GetComponent<GameCtrl> ().lineObjects.Add (this.gameObject);

		this.transform.rotation = Quaternion.Euler(90f, 0f,0f);

		player = gameObject.transform.parent.gameObject;
		startPos = player.transform.position;

		lineRenderer = this.GetComponent<LineRenderer> ();

		lineRenderer.numCornerVertices = 5; //角をなめらかにする度合い

		lineRenderer.SetPosition (0, startPos);
		lineRenderer.SetPosition (1, player.transform.position);

		buttonCtrl = GameObject.Find ("ButtonCtrl");
		touchMove = buttonCtrl.GetComponent<TouchMove> ();

		/*
		mats = lineRenderer.materials;
		mats [0] = material1;
		mats [1] = material2;
		*/
		//lineRenderer.material = material1;
	}
	
	// Update is called once per frame
	void Update () {

		if(activeUpdate == true){

		LineMove ();

		}

	}

	void LineMove(){

		int i = 0;

		if(first == true){
			delta = setPositionRate - 0.01f; // 2個目の座標を一瞬で生成したい とりあえず汚い書き方 1回だけ実行する Startで上手くいかなかった(???)
			delta += 1 * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){ //前進・後退している間のみ座標を生成する

			delta += 1 * Time.deltaTime;

		}

		if(touchMove.buttonForward || touchMove.buttonBack){
			delta += 1 * Time.deltaTime;
		}

		if(delta > setPositionRate){ // setPositionRate秒ごとに座標を固定する

			delta = 0;

			i += 1;

			int randomizer = Random.Range (0, 5);

			/*
			if (randomizer == 1 || randomizer == 2) {
				lineRenderer.material = material1;
			} else {
				lineRenderer.material = material2;
			}
			*/

			positionList.Add (this.transform.position);
			positionCount = positionList.Count;

			if(positionCount >= 3){
				lineRenderer.SetVertexCount (positionCount); // Listの要素数が3つ以上なら座標を要素数の数ぶん生成する
			}
				
			if(i >= 2){
				lineRenderer.SetPosition (i, positionList[i]); //はじめの2点は初期位置とプレイヤー位置をつなぎたいので3点目からコレを実行
			}

			first = false;
		}

		if (positionCount > 0) {
			lineRenderer.SetPosition (positionCount - 1, this.transform.position); //最新の座標に現在地を入れる
		} 

		if (positionCount == 2) {
			lineRenderer.SetPosition (0, startPos);
			lineRenderer.SetPosition (1, this.transform.position); //最新の座標に現在地を入れる(PositionCountが3点目から定義されるため個別で表記)
		} 
			
		if(Input.GetKey(KeyCode.Q) && positionCount > 1){ // StringMaker生成
			/*
			GameObject StringMaker = Instantiate (stringMakerPrefab, player.transform.position, Quaternion.identity);
			StringMaker.transform.parent = this.player.transform;
			//Destroy(this);
			activeUpdate = false;
			*/

			MakeStringMaker ();
		}

		/*
		if(Input.GetKeyDown(KeyCode.E)){

			DestroPositions = true;
			Debug.Log ("Ecode");
		
		}

		if(DestroPositions == true){

			Debug.Log ("Ecode2");

			float t = 0.1f;

			d += 1f * Time.deltaTime;
			Debug.Log (d);
			if (positionCount > 0 && d > t) {
				Num += 1;
				//positionCount -= 1;
				lineRenderer.SetVertexCount(positionCount - Num);
				d = 0f;
			}
		}
		*/
			
	}//LineMove()

	public void MakeStringMaker(){
		GameObject StringMaker = Instantiate (stringMakerPrefab, player.transform.position, Quaternion.identity);
		StringMaker.transform.parent = this.player.transform;
		//Destroy(this);
		activeUpdate = false;
	}

	public void DestroyPositions(){

		newPositionCount = positionCount;

		activeUpdate = false;

		float t = 0.1f;
		d += 1f * Time.deltaTime;
		//Debug.Log (d);
		if (newPositionCount > Num && d > t) {
			Num += 1;
			lineRenderer.SetVertexCount(newPositionCount - Num);
			//Debug.Log (newPositionCount - Num);
			d = 0f;
		}
	}
		
}
