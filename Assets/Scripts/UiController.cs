using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    public Text ScoreText;
    public List<GameObject> LifeIcons = new List<GameObject>();
    public GameObject GameOverPanel;
    public GameObject StartGamePanel;
    public GameObject PausePanel;

    void Start()
    {
        HideGameOver();
        HidePause();  
        ShowStart();
    }
    public void UpdateScoreText(int _value)
    {
        ScoreText.text = _value.ToString();
    }
    public void UpdateLives(int _value)
    {
        for (int i = LifeIcons.Count -1; i >= 0; i--)
        {
            LifeIcons[i].SetActive(_value >= i);
        }
    }
    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void HideGameOver()
    {
        GameOverPanel.SetActive(false);
    }
    public void ShowStart()
    {
        StartGamePanel.SetActive(true);
    }
    public void HideStart()
    {
        StartGamePanel.SetActive(false);
    }
    public void ShowPause()
    {
        PausePanel.SetActive(true);
    }
    public void HidePause()
    {
        PausePanel.SetActive(false);
    }
}
