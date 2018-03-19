using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float tilt;

    public float xMin, xMax, zMin, zMax;
    // Use this for initialization
    void Start()
    {

    }

    public GameObject shot;//子彈物件
    public Transform shotSpawn;//發射點
    public float fireRate;//發射間隔時間
    private float nextFire;

    public bool b_Shotgun = false;

    float _time = 5;
    // Update is called once per frame
    void Update()
    {
        if (b_Shotgun)
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                b_Shotgun = false;
                _time = 5;
            }
        }


        if (GameObject.Find("Button_Fire").GetComponent<Fire_Manager>()._press && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (b_Shotgun)
            {
                for (int i = 0; i < 10; i++)
                    Instantiate(shot, shotSpawn.position, Quaternion.Euler(0, (10 * i) - 45, 0));
            }
            else if (!b_Shotgun)
            {
                Instantiate(shot, shotSpawn.position, shot.transform.rotation);
            }

            gameObject.GetComponent<AudioSource>().Play();
        }

       float moveHorizontal = GameObject.Find("Joystick").GetComponent<Input_Manager>()._dir.x * Time.deltaTime * 30;
       float moveVertical = GameObject.Find("Joystick").GetComponent<Input_Manager>()._dir.y * Time.deltaTime * 30;
       //float moveHorizontal = Input.GetAxis("Horizontal");
       //float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        gameObject.GetComponent<Rigidbody>().velocity = movement * speed;


        gameObject.GetComponent<Rigidbody>().position = new Vector3
       (
           Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
           0.0f,
           Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax)
       );

        gameObject.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
