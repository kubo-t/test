using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{

    // Use this for initialization
    public void StringArgFunction(string s)
    {
        SceneManager.LoadScene(s);
    }
}
