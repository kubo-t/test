using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGetComponent : MonoBehaviour {

	/*

	CubeのInspector からこのスクリプトは非アクティブになっています。
	アクティブ(チェックボックスをオンに)にしてから実行してください。

	先ほどと違って Cube が空中に浮いたままなのがわかると思います。
	Start 関数内で isKinematic が true になったためです。

	this.rigidbody 内の数値にアクセスするには this.rigidbody の後ろにドットを打ちます。
	Start 関数内に this.rigidbody. を書いてみましょう。

	続けて、is と打ってみると予測が絞られて isKinematic を見つけられると思います。
	isKinematic は bool 変数で true でオン flase でオフにできます。

	ここまで読んだら、kyozaiフォルダ内部の奥出先生のデモシーンのスクリプトを見返してみると新たな気付きがあると思います。

	わからないことがあれば聞いてください。

	それでは「アタッチされたオブジェクトがplayerに接触されたときのみisKinematic = falseになるスクリプト」を実装してみましょう。
	playerタグを持つオブジェクトに接触したら～の条件内に入れるとよいです。

	*/

	public Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = this.GetComponent<Rigidbody> ();

		this.rigidbody.isKinematic = true;

		//↓　この中にthis.rigidbody.と打つと

		//↑　使える数値の一覧が出てきます
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
