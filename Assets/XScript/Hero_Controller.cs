using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Controller : MonoBehaviour {



    public GameObject[] all_monsters;
	// Use this for initialization
	void Start () {

        all_monsters = GameObject.FindGameObjectsWithTag("tag_mon");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < all_monsters.Length; i++)
            {
                all_monsters[i].GetComponent<Monster_Controller>().Dead();
            }
        }
	}
}
