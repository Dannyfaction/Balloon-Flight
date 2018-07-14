using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public static Action<float> UpdatePowerEvent;

    [SerializeField] private float baseShootCooldown = 1f;
    [SerializeField] private GameObject cannonballGameObject;
    [SerializeField] private GameObject ejectionPositionGameObject;

    private float power = 1;

    //private float shootCooldown;

	void Start () {
		
	}
	
	void Update () {
        /*
		if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        */
	}

    private void SetPower(Vector2 _mouseScreenPosition)
    {
        if (power < 50f)
        {
            power += 0.5f;
            UpdatePowerEvent(power);
        }

    }

    private void TriggerShoot(Vector2 _mouseScreenPosition)
    {
        if (!CutsceneManager.Instance.CurrentlyInCutscene)
        {
            //if (shootCooldown <= 0)
            //{
                //shootCooldown = baseShootCooldown;
                SpawnCannonball();

                power = 0;
                UpdatePowerEvent(power);
            //}
        }
    }

    private void SpawnCannonball()
    {
        GameObject _spawnedCannonball = GameObject.Instantiate(cannonballGameObject, ejectionPositionGameObject.transform.position, Quaternion.identity);
        Cannonball _cannonball = _spawnedCannonball.GetComponent<Cannonball>();
        _cannonball.Speed = power;
    }

    private void OnEnable()
    {
        PCInput.UpInputEvent += TriggerShoot;
        PCInput.InputEvent += SetPower;
    }

    private void OnDisable()
    {
        PCInput.UpInputEvent -= TriggerShoot;
        PCInput.InputEvent -= SetPower;
    }
}