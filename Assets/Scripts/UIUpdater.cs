using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

    [SerializeField] private Image powerMeterImage;

    private void UpdatePowerMeter(float _power)
    {
        powerMeterImage.fillAmount = _power * 2 / 100;
    }

    private void OnEnable()
    {
        Cannon.UpdatePowerEvent += UpdatePowerMeter;
    }

    private void OnDisable()
    {
        Cannon.UpdatePowerEvent -= UpdatePowerMeter;
    }
}
