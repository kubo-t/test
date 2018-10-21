using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour {

	private float delta = 0f;
	private float setPositionRate = 0.35f; // setPositionRateごとに座標を生成
	private Vector3 startPos; // 自身の初期位置
	private int i = 0; // 生成する座標の番号を入れる
	private int RecentPosNum; // 最新の座標の番号
	private LineRenderer lineRenderer; // LineRenderer

	private bool  destroyLine = false; // 追加
	private float destroyDelta = 0f; // 追加

	// Use this for initialization
	void Start () {
		lineRenderer = this.GetComponent<LineRenderer> ();

		lineRenderer.numCornerVertices = 5; //角をなめらかにする度合い

		lineRenderer.SetVertexCount (2); //lineRendererの頂点数

		startPos = this.transform.position;
		lineRenderer.SetPosition (0, startPos); // SetPosition(座標の順番、座標の位置);
	}
	
	// Update is called once per frame
	void Update () {

		if(destroyLine == false){ // 追加

			delta += 1 * Time.deltaTime; //プレイヤーが常に移動しない場合、移動中のみdeltaが加算されるようにする。
			/* 
			例）Wキー・Sキーを押している間キャラクターが移動する場合
			   if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
				delta += 1 * Time.deltaTime;
			}
			 */ 
				
			if (delta > setPositionRate) { // setPositionRate秒ごとに座標を固定する
				delta = 0;
				i += 1;

				lineRenderer.SetVertexCount (lineRenderer.positionCount + 1);
				lineRenderer.SetPosition (i, this.transform.position);
				}

			RecentPosNum = lineRenderer.positionCount - 1; // 配列の要素数-1が最新の要素の番号となる
			lineRenderer.SetPosition (RecentPosNum, this.transform.position); // 最新の座標に常に自身の位置を格納

			if(Input.GetKeyDown(KeyCode.Space)){
				destroyLine = true;
			}

		} // 追加

		// 追加 ↓
		if(destroyLine == true){
			float destroyTimer = 0.1f;

			destroyDelta += 1f * Time.deltaTime;

			if(destroyDelta > destroyTimer && lineRenderer.positionCount > 1){
				destroyDelta = 0f;
				lineRenderer.SetVertexCount (lineRenderer.positionCount - 1);
			}
		}
		// 追加 ↑

	}
}
