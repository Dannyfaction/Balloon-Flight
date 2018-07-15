using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public static Action<float> UpdatePowerEvent;

    [SerializeField] private GameObject cannonballGameObject;
    [SerializeField] private GameObject ejectionPositionGameObject;

    [SerializeField] private float minimumPower = 15f;
    [SerializeField] private float maximumPower = 40f;
    [SerializeField] private float powerIncrement = 0.15f;

    private float power;

    private void SetPower(Vector2 _mouseScreenPosition)
    {
        if (!CutsceneManager.Instance.CurrentlyInCutscene)
        {
            if (power < maximumPower)
            {
                power += powerIncrement;
                UpdatePowerEvent(power);
            }
        }
    }

    private void TriggerShoot(Vector2 _mouseScreenPosition)
    {
        if (!CutsceneManager.Instance.CurrentlyInCutscene)
        {
            SpawnCannonball();

            power = minimumPower;
            UpdatePowerEvent(power);
        }
    }

    private void SpawnCannonball()
    {
        GameObject _spawnedCannonball = GameObject.Instantiate(cannonballGameObject, ejectionPositionGameObject.transform.position, Quaternion.identity);
        Cannonball _cannonball = _spawnedCannonball.GetComponent<Cannonball>();
        _cannonball.Speed = power;
        AudioManager.Instance.PlayShootEffect();
    }

    private void OnEnable()
    {
        power = minimumPower;
        PCInput.UpInputEvent += TriggerShoot;
        PCInput.InputEvent += SetPower;
    }

    private void OnDisable()
    {
        PCInput.UpInputEvent -= TriggerShoot;
        PCInput.InputEvent -= SetPower;
    }
}