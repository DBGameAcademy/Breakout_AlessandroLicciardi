using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hits = 1;
    public int ScoreValue = 100;
    public AudioClip OnBreak;

    GameController gameController;

    private void Awake() {
        gameController = FindObjectOfType<GameController>();
    }
    public void OnHit()
    {
        hits--;
        if(hits <= 0)
        {
            gameController.AddScore(ScoreValue);
            gameController.audioController.PlayClip(OnBreak);
            Instantiate(gameController.explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
