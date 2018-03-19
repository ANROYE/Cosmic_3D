using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {



    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;//1
    public float startWait;//5
    public float waveWait;//10

    public Text scoreText;//分數文字
    public Text restartText;//重新開始文字
    public Text gameOverText;//遊戲結束文字

    private bool gameOver;//是否遊戲結束
    private bool restart;//是否重新開始
    private int score;//分數

    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, hazard.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "請任按一個地方重新開始";
                restart = true;
                break;
            }
        }
    }
    
    void Update () {
        if (restart)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("main");
            }
        }
    }

    //加分函式
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    //顯示分數
    private void UpdateScore()
    {
        scoreText.text = "分數: " + score;
    }
    //遊戲結束
    public void GameOver()
    {
        gameOverText.text = "遊戲結束!";
        gameOver = true;
    }

}
