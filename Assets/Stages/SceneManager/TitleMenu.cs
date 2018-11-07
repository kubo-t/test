using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    Button start1;
    Button exit;


    // Use this for initialization
    void Start()
    {
        start1 = GameObject.Find("/TitleWindow/MainPanel/StartButton").GetComponent<Button>();
        exit = GameObject.Find("/TitleWindow/MainPanel/EndButton").GetComponent<Button>();

        start1.Select();

    }

    // Update is called once per frame
    void Update()
    {

    }
}