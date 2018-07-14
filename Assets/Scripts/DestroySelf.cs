using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    [SerializeField] private float delay = 10f;

	void Start () {
        Invoke("DestroyGameObject", delay);
	}
	
	void Update () {
		
	}

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
