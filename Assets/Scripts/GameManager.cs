using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text livesText;
    public Text scoreText;

    public GameObject StartTarget;

    public Spawner targetSpawner;
    [HideInInspector]
    public int waveNumber = 1;

    int Lives = 10;
    int score = 0;

    public bool gameRunning = false;
    [HideInInspector]
    public bool waveComplete = true;

    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning && waveComplete ) {
            targetSpawner.SpawnWave(waveNumber);
            waveComplete = false;
        }
        if (Lives <= 0) {
            endGame();
        }
    }

    public void changeLife(int value) {
        Lives += value;
        livesText.text = "Lives: " + Lives;
    }

    public void addScore(int scoreValue) {
        score += scoreValue;
        scoreText.text = "Score: " + score;
    }

    public void StartGame() {
        score = 0;
        Lives = 10;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + Lives;
        gameRunning = true;
        waveComplete = true;
        
    }

    private void endGame() 
    {
        gameRunning = false;
        StartTarget.SetActive(true);
        targetSpawner.stopSpawn();
    }
}
