using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] asteroids = new GameObject[1];
    public GameObject player;

    public GUIText scoreText;
    public GUIText livesText;
    public GUIText restartText;
    public GUIText gameOverText;
        
    private bool restart;

    public Vector3 spawnValues;
    

    private int score;
    private int currentLives;
    private int currentCount;
    private int scoreTicker;

    public int startLives;
    public int startCount;
    public int waveIncrease;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    private void Start()
    {
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        restart = false;
        score = 0;
        scoreTicker = 0;
        currentCount = startCount;
        currentLives = startLives;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(SpawnWaves());
        UpdateLivesText();
        UpdateScore();
    }
    private void Update()
    {
        scoreTicker++;
        if (scoreTicker == 5 && restart == false)
        {
            scoreTicker = 0;
            score++;
            UpdateScore();
        }
        if (currentLives == 0) endGame();
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Start();
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
        UpdateLivesText();
    }
    public void Died()
    {
        currentLives-= 1;
        //Debug.Log("Lives = " +currentLives);
        UpdateLivesText();
        if (currentLives > 0)
        {
            Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            restart = true;
        }
    }
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + currentLives;
    }
    
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    void endGame()
    {
        gameOverText.text = "Game Over";
        restart = true;
        restartText.text = "Press 'R' for restart";
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Enemy");
        StopAllCoroutines();
        for(int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (currentLives > 0)
        {
            for (int i = 0; i < currentCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                int next = Random.Range(0, asteroids.Length);
                Instantiate(asteroids[next], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            currentCount += waveIncrease;
            yield return new WaitForSeconds(waveWait);
        }
    }
}
