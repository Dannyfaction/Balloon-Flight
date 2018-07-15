using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance { get { return GetInstance(); } }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public int TotalBalloonsInLevel
    {
        get
        {
            return totalBalloonsInLevel;
        }
        set
        {
            totalBalloonsInLevel = value;
        }
    }

    #region Singleton
    private static ScoreManager instance;

    private static ScoreManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<ScoreManager>();
        }
        return instance;
    }
    #endregion

    private int score = 0;
    private int totalBalloonsInLevel;
}