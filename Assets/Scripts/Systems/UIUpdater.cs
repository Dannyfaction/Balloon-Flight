using SplineTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

    [SerializeField] private Image powerMeterImage;
    [SerializeField] private Text scoreText;

    private void UpdatePowerMeter(float _power)
    {
        powerMeterImage.fillAmount = (_power-15) * 2 / 50;
    }

    private void UpdateScore()
    {
        scoreText.text = ScoreManager.Instance.Score  + " / " + ScoreManager.Instance.TotalBalloonsInLevel;
    }

    private void OnEnable()
    {
        Cannon.UpdatePowerEvent += UpdatePowerMeter;
        FollowSpline.FinishedFollowingSpline += UpdateScore;
    }

    private void OnDisable()
    {
        Cannon.UpdatePowerEvent -= UpdatePowerMeter;
        FollowSpline.FinishedFollowingSpline -= UpdateScore;
    }
}
