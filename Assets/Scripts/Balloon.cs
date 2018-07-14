using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    [SerializeField] private BalloonType balloonType;
    [SerializeField] private GameObject confettiPrefabGameObject;

    private void OnTriggerEnter(Collider _collision)
    {
        if (_collision.transform.tag == "Cannonball")
        {
            GameObject _confetti = GameObject.Instantiate(confettiPrefabGameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}

public enum BalloonType
{
    Red,
    Green,
    Blue,
    Purple,
    Yellow
}