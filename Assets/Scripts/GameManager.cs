using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text livesText;
    public Text scoreText;
    public Text NameText;

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
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        NameText.text = PersistantData.Instance.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning && waveComplete ) {
            targetSpawner.SpawnWave(waveNumber);
            waveComplete = false;
        }
        if (Lives <= 0&& gameRunning) {
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
        //disable remaining targets
        var remainingTargets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject tValue in remainingTargets) {
            if (tValue.activeSelf&& tValue.name!="Menu") {
                
                tValue.SetActive(false);
            }
        }
        //reset game
        gameRunning = false;
        StartTarget.SetActive(true);
        targetSpawner.stopSpawn();
        //SAVE SCORE
        PersistantData.Instance.addHighScore(score);
        PersistantData.Instance.saveHighScores();
        
    }

    public void loadmenu() {
        if (gameRunning) 
        {
            endGame();
        }
        SceneManager.LoadScene(0);
    }
}
