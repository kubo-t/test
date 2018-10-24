using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkNessDragon : MonoBehaviour {

	/*

	GetComponentのテスト用スクリプトです。
	
	先ほどの"GetComponentScript"スクリプトと見比べてください。
	rigidbody と darkNessDragon　が入れ替わっても起きていることは同じです。
	int や float と同じく自由に名前を決められます。

	public int i;

	void Start(){
		this.i = 100;
	}

	とほぼ同じ挙動であるということです。
	int と違い Rigidbody は "100"という数字ではなく、"Rigidbody"というコンポーネントを入れられます。

	では次はRigidbody内部の数値にアクセスしていきます。
	”UseGetComponent”スクリプトを開いてください。



	public Rigidbody darkNessDragon; について
		public: アクセス修飾子publicを持つ型は他のスクリプトからアクセスでき、かつInspector上に表示される。
		Rigidbosy: 型　箱と形容されることが多い。コイツ自身は「なんか今からRigidbosyを使うんだな」と思っているだけというイメージ。
		darkNessDragon:　変数の名前。頭は小文字という制限の下、自由に決められる。今回は「これから"darkNessDragon"という名前のRigidbodyを使うんだなあ」という感じ。

	this.darkNessDragon = this.GetComponent<Rigidbody> (); について
		this: このスクリプト内の変数、またはこのスクリプトがアタッチされているオブジェクトが持っていることを意味している。
		this.darkNessDragon:　例えばこの場合、このスクリプトが持っているdarkNessDragon変数である。
		this.GetComponent<Rigidbody>():　例えばこの場合、Cubeオブジェクトの持っているRigidbodyコンポーネントを取得する。

	*/

	public Rigidbody darkNessDragon;

	// Use this for initialization
	void Start () {
		this.darkNessDragon = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
