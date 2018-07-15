using SplineTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get { return GetInstance(); } }

    public int LevelIndex
    {
        get
        {
            return levelIndex;
        }
    }

    #region Singleton
    private static LevelManager instance;

    private static LevelManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<LevelManager>();
        }
        return instance;
    }
    #endregion

    [SerializeField] private List<GameObject> levelPrefabs;
    [SerializeField] private FollowSpline airBalloonFollowSpline;

    private GameObject currentSpawnedLevel;

    private int levelIndex;

    public void SpawnLevel()
    {
        currentSpawnedLevel = Instantiate(levelPrefabs[levelIndex - 1], Vector3.zero, Quaternion.identity);
        airBalloonFollowSpline.SetSpline(currentSpawnedLevel.transform.GetChild(0).GetComponent<SplineWindow>());
        ScoreManager.Instance.Score = 0;
        ScoreManager.Instance.TotalBalloonsInLevel = currentSpawnedLevel.transform.childCount - 1;
    }

    public void RemoveLevel()
    {
        Debug.Log("destroyed");
        Destroy(currentSpawnedLevel);
    }

    public void SetLevelIndex(int _levelIndex)
    {
        levelIndex = _levelIndex;
    }
}