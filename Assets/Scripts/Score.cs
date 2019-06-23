﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        int[,] kill;
        kill = GameManager.GetInstance().kill;
        print("kill " + kill[0,0]);
        print("GM kill " + GameManager.GetInstance().kill[0, 0]);
        int[] scoreArray = { 100, 200, 300, 400 }; // score of 4 types of enemy tank
        Text P1T1 = GameObject.Find("P1T1").GetComponent<Text>();
        P1T1.text = kill[0, 0].ToString();
        Text P1S1 = GameObject.Find("P1S1").GetComponent<Text>();
        P1S1.text = (kill[0, 0] * scoreArray[0]).ToString() + " PTS";
        Text P1T2 = GameObject.Find("P1T2").GetComponent<Text>();
        P1T2.text = kill[0, 1].ToString();
        Text P1S2 = GameObject.Find("P1S2").GetComponent<Text>();
        P1S2.text = (kill[0, 1] * scoreArray[1]).ToString() + " PTS";
        Text P1T3 = GameObject.Find("P1T3").GetComponent<Text>();
        P1T3.text = kill[0, 2].ToString();
        Text P1S3 = GameObject.Find("P1S3").GetComponent<Text>();
        P1S3.text = (kill[0, 2] * scoreArray[2]).ToString() + " PTS";
        Text P1T4 = GameObject.Find("P1T4").GetComponent<Text>();
        P1T4.text = kill[0, 3].ToString();
        Text P1S4 = GameObject.Find("P1S4").GetComponent<Text>();
        P1S4.text = (kill[0, 3] * scoreArray[3]).ToString() + " PTS";
        Text P1T = GameObject.Find("P1T").GetComponent<Text>();
        P1T.text = (kill[0, 0] + kill[0, 1] + kill[0, 2] + kill[0, 3]).ToString();
        Text P1S = GameObject.Find("P1S").GetComponent<Text>();
        P1S.text = (kill[0, 0] * scoreArray[0] + kill[0, 1] * scoreArray[1] + kill[0, 2] * scoreArray[2] + kill[0, 3] * scoreArray[3]).ToString() + " PTS";
        Text P2T1 = GameObject.Find("P2T1").GetComponent<Text>();
        P2T1.text = kill[1, 0].ToString();
        Text P2S1 = GameObject.Find("P2S1").GetComponent<Text>();
        P2S1.text = (kill[1, 0] * scoreArray[0]).ToString() + " PTS";
        Text P2T2 = GameObject.Find("P2T2").GetComponent<Text>();
        P2T2.text = kill[1, 1].ToString();
        Text P2S2 = GameObject.Find("P2S2").GetComponent<Text>();
        P2S2.text = (kill[1, 1] * scoreArray[1]).ToString() + " PTS";
        Text P2T3 = GameObject.Find("P2T3").GetComponent<Text>();
        P2T3.text = kill[1, 2].ToString();
        Text P2S3 = GameObject.Find("P2S3").GetComponent<Text>();
        P2S3.text = (kill[1, 2] * scoreArray[2]).ToString() + " PTS";
        Text P2T4 = GameObject.Find("P2T4").GetComponent<Text>();
        P2T4.text = kill[1, 3].ToString();
        Text P2S4 = GameObject.Find("P2S4").GetComponent<Text>();
        P2S4.text = (kill[1, 3] * scoreArray[3]).ToString() + " PTS";
        Text P2T = GameObject.Find("P2T").GetComponent<Text>();
        P2T.text = (kill[1, 0] + kill[1, 1] + kill[1, 2] + kill[1, 3]).ToString();
        Text P2S = GameObject.Find("P2S").GetComponent<Text>();
        P2S.text = (kill[1, 0] * scoreArray[0] + kill[1, 1] * scoreArray[1] + kill[1, 2] * scoreArray[2] + kill[1, 3] * scoreArray[3]).ToString() + " PTS";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
