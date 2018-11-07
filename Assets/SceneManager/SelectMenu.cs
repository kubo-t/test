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


    // Use this for initialization
    void Start () {
        stage1 = GameObject.Find("/Canvas/SelectButton1").GetComponent<Button>();
        stage2 = GameObject.Find("/Canvas/SelectButton2").GetComponent<Button>();
        stage3 = GameObject.Find("/Canvas/SelectButton3").GetComponent<Button>();
        stage4 = GameObject.Find("/Canvas/SelectButton4").GetComponent<Button>();
        stage5 = GameObject.Find("/Canvas/SelectButton5").GetComponent<Button>();
        stage6 = GameObject.Find("/Canvas/SelectButton6").GetComponent<Button>();

        stage1.Select();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
