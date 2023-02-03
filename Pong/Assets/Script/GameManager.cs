using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int playerScore01 = 0;
    private static int playerScore02 = 0;
    public GUISkin theSkin;
    public Transform theBall;

    public static void Score(String wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else
        {
            playerScore02 += 1;
        }
    }

    private void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 100, 0, 100, 200), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 100, 0, 100, 200), "" + playerScore02);
        if (GUI.Button(new Rect(Screen.width / 2 - 100 / 2, 35, 120, 50), "Reset"))
        {
            playerScore01 = 0;
            playerScore02 = 0;
            theBall.gameObject.SendMessage("ResetBall");
        }
    }
}