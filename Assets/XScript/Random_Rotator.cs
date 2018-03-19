using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotator : MonoBehaviour {

    public float tumble;
	
	// Update is called once per frame
	void Start () {
       gameObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

}
