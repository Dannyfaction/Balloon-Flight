using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance { get { return GetInstance(); } }

    #region Singleton
    private static AudioManager instance;

    private static AudioManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<AudioManager>();
        }
        return instance;
    }
    #endregion

    [SerializeField] private AudioSource balloonPopEffect;

    public void PlayBalloonPopEffect()
    {
        balloonPopEffect.time = 0.1f;
        balloonPopEffect.Play();
    }
}
