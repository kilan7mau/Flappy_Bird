using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private GameManagerLogic logic;

    private void Start()
    {
        logic = GameManagerLogic.GetInstance();
        logic.SetUI(this);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowPlayButton()
    {
        playButton.SetActive(true);
    }

    public void HidePlayButton()
    {
        playButton.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOver.SetActive(false);
    }

    public void OnPlayButtonClick()
    {
        logic.Play();
    }
}
