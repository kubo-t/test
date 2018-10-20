using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*-----------------------注意-----------------------*/
//アクション部分が実装できるかの確認用スクリプトです
//
//マーカーのセット部分とwallの移動・回転部分が混在していて汚いです
//
//適当にfor文回しているのでエラーを吐きます
//実行できない、実行しても止まる場合はConsoleからError Pauseを無効にして実行してください
//
//*--------------------------------------------------*/

//*-----------------------<コピペ用>-----------------------*/
//*--------------------------------------------------*/

public class SetMarker : MonoBehaviour {

	public GameObject markerPrefab;
	public GameObject wallPrefab;
	public GameObject wall;

	private bool wallInGame = false;

	//public GameObject wall;
	//[SerializeField] private float wallAddPower = 0.0f;

	private List<GameObject> markList = new List<GameObject>();

	private Vector3 target;

	public int markCount = 0;

	private	Vector3 minPos;
	private	Vector3 mdlPos;
	private	Vector3 maxPos;

	private	Vector2 minVec2;
	private	Vector2 mdlVec2;
	private	Vector2 maxVec2;

	// Use this for initialization
	void Start () {
		//wall = GameObject.Find ("Wall");
		//wall.transform.position = new Vector3 (0f, -10f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			Marking ();
		}

		//for(int i = 0; i < markList.Count; i++){

		if (markCount == 3) {

			//Debug.Log (markCount);

			minPos = markList [0].transform.position;
			mdlPos = markList [1].transform.position;
			maxPos = markList [2].transform.position;

			//this.

			//*-----------------------目標-----------------------*/
			//始点...1つ目の赤cube
			//中間点...2つ目の赤cube
			//終点...3つ目の赤cube
			//見えない壁(wall)...実際に物理演算を行うオブジェクトの座標を持つ　*今は開発の利便性のため見えるようになっている
			//
			//始点の座標と終点の座標を通る直線を求める
			//その直線と垂直に交わり、中間点を通る直線との交点を求める
			//見えない壁(wall)が、その交点の方向を向くようにする
			//見えない壁が始点と終点の中点に向かって力を加える　→　これが輪ゴムをはじく動きの本体
			//
			//*--------------------------------------------------*/

			float xa = markList [0].transform.position.x; //始点のx座標
			float ya = markList [0].transform.position.z; //始点のy座標
			float xb = markList [2].transform.position.x; //終点のx座標
			float yb = markList [2].transform.position.z; //終点のy座標
			float xp = markList [1].transform.position.x; //中間点のx座標
			float yp = markList [1].transform.position.z; //中間点のy座標

			float ha = markList [0].transform.position.y;
			float hb = markList [2].transform.position.y;

			//始点A(ax, ay)と終点B(bx, by)を通る直線abと、直線abに対して垂直かつ中間点P(xp, yp)を通る直線ABとの交点Q(xq, yq)を求める
			float a = (yb - ya) / (xb - xa); //直線abの傾きa
			float b = yb - (a * xb); //直線abの補正値b

			float A = -1 / a; //直線ABの傾きA
			float B = yp - (A * xp); //直線ABの補正値B

			float xq = (B - b) / (a - A); //xqを求める
			float yq = A * xq + B; //yqを求める

			//(zq, yq)をVector3 targetに格納
			//Vector3 target;
			target = new Vector3 (xq, (ha + hb)/2, yq);

			//始点A(xa, ya)と終点B(xb, yb)の中点L(xl, yl)を求める
			float xl = (xa + xb) / 2;
			float yl = (ya + yb) / 2;

			float scaleDis = Mathf.Abs(Vector3.Distance (minPos, maxPos));

			if(!wallInGame){
				wall = Instantiate (wallPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
				wall.transform.position = mdlPos; //wallを中点の座標へ移動
				wall.transform.rotation = Quaternion.Euler(0f, 0f,0f);
				wall.transform.localScale = new Vector3 (scaleDis, 1f, 1f);
				wall.transform.LookAt (target); // wallをtargetへ向かせる

				wallInGame = true;
			}

		}

		if(Input.GetKeyDown(KeyCode.E)){
			//wall.GetComponent<Rigidbody> ().AddForce(wall.GetComponent<WallScriot>().wallForward * wallAddPower);
			//wall.GetComponent<WallScriot>().WallAddForce();
			markList.Clear ();
			markCount = 0;
			wallInGame = false;
			Debug.Log ("DeleteList");
		}


			//Debug.Log (minPos.x);// minPos.y  minPos.z, maxPos.x, maxPos.y, maxPos.z);
		//}
	}

	void Marking(){
		//int markCount = 0;
		if(markCount <= 2){
			markList.Add (Instantiate (markerPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity));

			markCount += 1;
		}
	}
		

















}
