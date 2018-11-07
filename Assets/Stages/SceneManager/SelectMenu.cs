using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour {
	
    Button stage1;
    Button stage2;
    Button stage3;
    Button stage4;
    Button stage5;
    Button stage6;
	Button stage7;

	SaveManager saveManager;

    // Use this for initialization
    void Start () {
        stage1 = GameObject.Find("/Canvas/Button1").GetComponent<Button>();
        stage2 = GameObject.Find("/Canvas/Button2").GetComponent<Button>();
        stage3 = GameObject.Find("/Canvas/Button3").GetComponent<Button>();
        stage4 = GameObject.Find("/Canvas/Button4").GetComponent<Button>();
        stage5 = GameObject.Find("/Canvas/Button5").GetComponent<Button>();
        stage6 = GameObject.Find("/Canvas/Button6").GetComponent<Button>();
		stage7 = GameObject.Find("/Canvas/Button7").GetComponent<Button>();

		saveManager = GameObject.Find ("DataLoad").GetComponent<SaveManager>();
		saveManager.DataLoad ();

		stage1.enabled = false;
		stage2.enabled = false;
		stage3.enabled = false;
		stage4.enabled = false;
		stage5.enabled = false;
		stage6.enabled = false;
		stage7.enabled = false;

		stage1.image.color = Color.gray;
		stage2.image.color = Color.gray;
		stage3.image.color = Color.gray;
		stage4.image.color = Color.gray;
		stage5.image.color = Color.gray;
		stage6.image.color = Color.gray;
		stage7.image.color = Color.gray;

		if(saveManager.clearedStage[1] == true){
			stage1.enabled = true;
			stage1.image.color = Color.white;
		}
		if(saveManager.clearedStage[2] == true){
			stage2.enabled = true;
			stage2.image.color = Color.white;
		}
		if(saveManager.clearedStage[3] == true){
			stage3.enabled = true;
			stage3.image.color = Color.white;
		}
		if(saveManager.clearedStage[4] == true){
			stage4.enabled = true;
			stage4.image.color = Color.white;
		}
		if(saveManager.clearedStage[5] == true){
			stage5.enabled = true;
			stage5.image.color = Color.white;
		}
		if(saveManager.clearedStage[6] == true){
			stage6.enabled = true;
			stage6.image.color = Color.white;
		}
		if(saveManager.clearedStage[7] == true){
			stage7.enabled = true;
			stage7.image.color = Color.white;
		}



    }

    // Update is called once per frame
    void Update () {
		
	}
}
