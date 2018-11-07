using UnityEngine;
using System; // UnityJsonを使う場合に必要
using System.IO; // ファイル書き込みに必要

// [Serializable] をつけないとシリアライズできない
[Serializable]
public struct SaveData {

	//public int stageNum;

	//public bool[] clearedStage = new bool[8];
	public bool[] clearedStage;

	//public int x;
	//public int y;

	public void Dump() {
		//Debug.Log("x = " + x);
		//Debug.Log("y = " + y);

		//Debug.Log (stageNum);
	}
}

/// <summary>
/// セーブデータ管理
/// </summary>
public class SaveManager : MonoBehaviour {

	public int stageNum;
	public bool[] clearedStage = {false,false,false,false,false,false,false,false};

	//private int totalStageNum;

	// 保存するファイル
	const string SAVE_FILE_PATH = "save.txt";

	void Start(){
		var data = new SaveData ();

		//data.stageNum = this.stageNum;
		//totalStageNum = clearedStage.Length;


		//for(int i = 0;i <= this.stageNum;i++){
		//	data.clearedStage [i] = true;
		//}

		var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
		var reader = new StreamReader (info.OpenRead ());
		var jsonLoad = reader.ReadToEnd ();
		var dataLoad = JsonUtility.FromJson<SaveData>(jsonLoad);

		data.clearedStage = new bool[this.clearedStage.Length]; //clearedStageを初期化

		for(int i = 0;i < this.clearedStage.Length;i++){
			data.clearedStage [i] = dataLoad.clearedStage [i]; //clearedStageにsave.txtからLoadしたものを入れる
		}

		reader.Close ();


		data.clearedStage [this.stageNum] = true; // claredStage[現在のステージ]をtrueにして　↓save

		for(int i = 0;i < this.clearedStage.Length;i++){ // ここまではちゃんと動くけど
			Debug.Log (data.clearedStage[i]);
		}
			
		// JSONにシリアライズ
		var json = JsonUtility.ToJson (data);
		// Assetsフォルダに保存する
		var path = Application.dataPath + "/" + SAVE_FILE_PATH;
		var writer = new StreamWriter (path, false); // 上書き
		writer.WriteLine (json);
		writer.Flush ();
		writer.Close ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			
			// Sキーでセーブ実行
			//var data = new SaveData ();
			//data.x = 5;
			//data.y = 7;
			//data.clearStageNum = this.clearStageNum;
			// JSONにシリアライズ
			//var json = JsonUtility.ToJson (data);
			// Assetsフォルダに保存する
			//var path = Application.dataPath + "/" + SAVE_FILE_PATH;
			//var writer = new StreamWriter (path, false); // 上書き
			//writer.WriteLine (json);
			//writer.Flush ();
			//writer.Close ();

		} else if (Input.GetKeyDown (KeyCode.L)) {
			// Lキーでロード実行
			// Assetsフォルダからロード

			var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
			var reader = new StreamReader (info.OpenRead ());
			var json = reader.ReadToEnd ();
			var data = JsonUtility.FromJson<SaveData>(json);
			data.Dump();

			for(int i = 0;i < this.clearedStage.Length;i++){ // ここで入ってない？？？？？？？ Saveミスってそう
				Debug.Log (data.clearedStage[i]);
			}

		}
	}

	public void DataLoad(){
		var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
		var reader = new StreamReader (info.OpenRead ());
		var json = reader.ReadToEnd ();
		var data = JsonUtility.FromJson<SaveData>(json);
		data.Dump();

		for(int i = 0;i < this.clearedStage.Length;i++){
			this.clearedStage [i] = data.clearedStage [i];
		}
		//this.stageNum = data.stageNum;
		//Debug.Log (this.stageNum);
	}
}