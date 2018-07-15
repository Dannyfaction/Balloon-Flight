using SplineTool;
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

    [SerializeField] private ScriptedAnimationController scriptedAnimationController;

    [SerializeField] private GameObject airBalloon;
    private Vector3 airBalloonStartPosition;
    [SerializeField] private GameObject gameCutsceneCanvas;

    [SerializeField] private GameObject cutsceneCamera;
    [SerializeField] private GameObject cutsceneCanvas;

    [SerializeField] private List<GameObject> gameOverCanvasObjects;

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
        airBalloonStartPosition = airBalloon.transform.position;
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
        scriptedAnimationController.StartAnimation(ScriptedAnimationType.In, InBetweenFades);
    }

    private void InBetweenFades()
    {
        CoroutineHelper.DelayTime(1f, StartScreenFadeOut);
        if (currentlyInCutscene)
        {
            cutsceneCamera.SetActive(false);
            cutsceneCanvas.SetActive(false);
            airBalloon.SetActive(true);
            gameCutsceneCanvas.SetActive(true);
            LevelManager.Instance.SpawnLevel();
        }
        else
        {
            airBalloon.SetActive(false);
            gameCutsceneCanvas.SetActive(false);
            cutsceneCamera.SetActive(true);
            cutsceneCanvas.SetActive(true);
            for (int i = 0; i < gameOverCanvasObjects.Count; i++)
            {
                gameOverCanvasObjects[i].SetActive(true);
            }
            airBalloon.transform.position = airBalloonStartPosition;
            FollowSpline _followSpline = airBalloon.GetComponent<FollowSpline>();
            //MoveObject _moveObject = airBalloon.GetComponent<MoveObject>();
            //_moveObject.speed = 6f;
            _followSpline.StartMoving(0, 0, 0, false);
            LevelManager.Instance.RemoveLevel();
        }
    }

    private void StartScreenFadeOut()
    {
        scriptedAnimationController.StartAnimation(ScriptedAnimationType.Out, FadeScreenCompletion);

    }

    private void FadeScreenCompletion()
    {
        currentlyInCutscene = !currentlyInCutscene;
    }
}