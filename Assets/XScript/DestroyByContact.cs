using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    private GameManager gameController;


    void Start()
    {
        GameObject gameControllerObject = GameObject.Find("ApplicationGameMaker");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameManager>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "tag_HP")
        {
            return;
        }

        if (explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            if (explosion != null)
                Instantiate(explosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
