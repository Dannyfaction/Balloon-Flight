using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    private Rigidbody rigidbody;
    [SerializeField] private float speed;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Camera.main.transform.forward * speed, ForceMode.Impulse);
	}
}