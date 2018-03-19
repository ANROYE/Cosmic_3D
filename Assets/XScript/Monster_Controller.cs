using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour {


    public void Dead()
    {
        Destroy(gameObject);
    }
}
