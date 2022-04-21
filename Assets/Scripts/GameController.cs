using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score = 0;

    public UiController uiController;
    public Ball Ball;
    public Vector3 Ballresetposition;
    private bool IsPlaying;
    public bool isPlaying { get { return IsPlaying; } }
    private bool IsPaused;
    public bool isPaused{ get { return IsPaused; } }
    public int Lives = 3;
    public int InitialLives = 3;
    public AudioController audioController;
    public BlockController blockController;
    public GameObject explosion;
    public void Start()
    {
        uiController.UpdateScoreText(Score);
        uiController.UpdateLives(Lives);
        PauseGame();
    }
    public void AddScore(int _value)
    {
        Score += _value;
        uiController.UpdateScoreText(Score);
    }
    public void BallLost()
    {
        Ball.transform.position = Ballresetposition;
        Vector3 currentVelocity = Ball.velocity;
        currentVelocity.y = Mathf.Abs(currentVelocity.y);
        Ball.velocity = currentVelocity;

        Lives--;
        uiController.UpdateLives(Lives);
        if(Lives < 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        uiController.ShowGameOver();
        IsPlaying = false;
        PauseGame();
    }
    public void StartGame()
    {
        IsPlaying = true;
        ResetGame();
        UnPauseGame();
    }
    void ResetGame()
    {
        Lives = InitialLives;
        Score = 0;
        uiController.UpdateScoreText(Score);
        uiController.UpdateLives(Lives);
        uiController.HideStart();
        uiController.HideGameOver();
        blockController.ResetBlock();
    }
    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
        if (IsPlaying)
        {
            uiController.ShowPause();
        }
    }
    public void UnPauseGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
        uiController.HidePause();
    }
    public void QuitGame()
    {
        IsPlaying = false;
        PauseGame();
        uiController.HideGameOver();
        uiController.HidePause();
        uiController.ShowStart();
        Ball.transform.position = Ballresetposition;
    }
}

