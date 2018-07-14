using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get { return GetInstance(); } }

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

    private int levelIndex;

    public void SpawnLevel()
    {
        GameObject _spawnedLevel = Instantiate(levelPrefabs[levelIndex - 1], Vector3.zero, Quaternion.identity);
    }

    public void SetLevelIndex(int _levelIndex)
    {
        levelIndex = _levelIndex;
    }
}