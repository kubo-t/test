using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {

	// Use this for initialization
	public void GameStart() {
        SceneManager.LoadScene("StageSelect");
	}
	
	// Update is called once per frame
	public void GameEnd() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
		        Application.OpenURL("http://www.yahoo.co.jp/");
        #else
		        Application.Quit();
        #endif
    }
}
