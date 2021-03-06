﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour {

    public float GameOverScreenDelay = 2.0f;
    public float WinScreenDelay = 2.0f;
    public string GameOverScene = "GameOver";
    public string AsteroidScene = "Asteroids";
    public string PostAsteroidScene = "PostAsteroids";
    public string BossBattleScene = "BossBattle";
    public string WinScene = "WinScene";
    public string MainMenuScene = "Menu";
    public string EnemyScene = "Enemies";
    private uint CurrentScore = 0;
    public uint CurrentAsteroids;
    public static GameStateController Instance { get; private set; }

    private string lastScene;
    
    private List<Vector4> playerPositionAtTime; // I could not find a generic hash table
    private GameObject player;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentAsteroids(uint count)
    {
        CurrentAsteroids = count;
    }
    public void RegisterPlayer(GameObject playerToSet)
    {
        if (!player)
        {
            player = playerToSet;
            if (SceneManager.GetActiveScene().name == AsteroidScene)
            {
                CurrentScore = 0;
            }
        }
    }
    





	public void OnPlayerDied()
	{
        player = null;
		Invoke ("ShowGameOverScreen", GameOverScreenDelay);
	}

    public void OnBossDied()
    {
        //might load other scenes in the future
        OnPlayerWin();
    }
    public void OnPlayerWin()
    {
        Invoke("ShowWinScreen", WinScreenDelay);
    }
    public void OnAsteroidsKilled()
    {
        LoadPostAsteroidScene();
        Invoke("LoadEnemyScene", 5);
            //LoadEnemyScene();
    }
    public void LoadPostAsteroidScene()
    {
        SceneManager.LoadScene(PostAsteroidScene);
    }
    public void OnEnemiesKilled()
    {
        LoadBossBattleScene();
    }
	public void IncrementScore(uint scoreToAdd)
	{
		CurrentScore += scoreToAdd;
	}
	public uint GetCurrentScore()
	{
		return CurrentScore;
	}


	public void ShowGameOverScreen()
	{
        SceneManager.LoadScene(GameOverScene);
        
        
	}
    public void ShowWinScreen()
    {
        SceneManager.LoadScene(WinScene);
        
    }
    public void ShowMainMenuScreen()
    {
        SceneManager.LoadScene(MainMenuScene);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadAsteroidScene()
    {
        SceneManager.LoadScene(AsteroidScene);
        lastScene = AsteroidScene;
        //AsteroidSpawner.Instance.RegisterPlayer(player);
    }
    public void LoadBossBattleScene()
    {
        SceneManager.LoadScene(BossBattleScene);
        lastScene = BossBattleScene;
    }
    public void LoadEnemyScene()
    {
        SceneManager.LoadScene(EnemyScene);
        lastScene = EnemyScene;
        //EnemySpawner.Instance.RegisterPlayer(player);
    }
    public void LoadLastScene()
    {
        SceneManager.LoadScene(lastScene);
    }

}
