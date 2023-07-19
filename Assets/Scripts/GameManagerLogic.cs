using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    public static GameManagerLogic instance;

    public Player player;
    public Spawner spawner;
    public int score { get; private set; }

    private GameManagerUI ui;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public static GameManagerLogic GetInstance()
    {
        return instance;
    }

    public void SetUI(GameManagerUI ui)
    {
        this.ui = ui;
    }

    public void Play()
    {
        score = 0;

        ui.HidePlayButton();
        ui.HideGameOver();

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        ui.ShowPlayButton();
        ui.ShowGameOver();

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        ui.UpdateScore(score);
    }
}
