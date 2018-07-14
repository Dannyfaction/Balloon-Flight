using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

    //public static Action FadeScreenCompleted;

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

    [SerializeField] private List<ScriptedAnimationController> scriptedAnimationControllers;

    [SerializeField] private GameObject airBalloon;

    [SerializeField] private GameObject cutsceneCamera;
    [SerializeField] private GameObject cutsceneCanvas;

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

	private void Awake () {
        currentlyInCutscene = true;
    }

    /// <summary>
    /// This function starts the screen fade sequences to switch between Cutscene and Gamescene
    /// </summary>
    public void SwitchCutSceneState()
    {
        StartScreenFadeIn();
    }

    private void StartScreenFadeIn()
    {
        for (int i = 0; i < scriptedAnimationControllers.Count; i++)
        {
            scriptedAnimationControllers[i].StartAnimation(ScriptedAnimationType.In, InBetweenFades);
        }
    }

    private void InBetweenFades()
    {
        CoroutineHelper.DelayTime(1f, StartScreenFadeOut);
        if (currentlyInCutscene)
        {
            cutsceneCamera.SetActive(false);
            cutsceneCanvas.SetActive(false);
            airBalloon.SetActive(true);
            LevelManager.Instance.SpawnLevel();
        }
        else
        {
            airBalloon.SetActive(false);
            cutsceneCamera.SetActive(true);
            cutsceneCanvas.SetActive(true);
        }
    }

    private void StartScreenFadeOut()
    {
        for (int i = 0; i < scriptedAnimationControllers.Count; i++)
        {
            if (scriptedAnimationControllers[i].transform.root.gameObject.activeSelf)
            {
                scriptedAnimationControllers[i].StartAnimation(ScriptedAnimationType.Out, FadeScreenCompletion);
            }

        }
    }

    private void FadeScreenCompletion()
    {
        currentlyInCutscene = !currentlyInCutscene;
    }


}