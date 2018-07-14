using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

    public static CutsceneManager Instance { get { return GetInstance(); } }

    #region Singleton
    private static CutsceneManager instance;

    private static CutsceneManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<CutsceneManager>();
        }
        return instance;
    }
    #endregion

    public bool CurrentlyInCutscene { 
        get
        {
            return currentlyInCutscene;
        }
        set
        {
            currentlyInCutscene = value;
        }
    }

    private bool currentlyInCutscene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
