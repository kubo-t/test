using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponentScript : MonoBehaviour {

	/*

	GetComponentのテスト用スクリプトです。
	Hierarchy > Cube > GetComponentScript > Rigidbody > None(rigidbody) の部分を見てください。
	実行すると、None(rigidbody) に Cube(rigidbody) が入りました。

	このスクリプト内の枠になんかが入ることを”取得”といいます。

	では次は以下のスクリプトがどういう意味かを説明します。
	”DarkNessDragon”スクリプトを開いてください。

	*/

	public Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = this.GetComponent<Rigidbody> ();
	}

	/*



	*/
	
	// Update is called once per frame
	void Update () {
		
	}

}
