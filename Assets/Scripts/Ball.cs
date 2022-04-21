using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameObject lastobjecthit;
    CircleCollider2D circlecollider;
    GameController gameController;
    public AudioClip OnWallHit;
    public AudioClip OnPaddleHit;
    public Vector2 velocity = new Vector2(4,4);

    private void Awake()
    {
        circlecollider = GetComponent<CircleCollider2D>();
        gameController = FindObjectOfType<GameController>();
    }
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, circlecollider.radius, velocity, (velocity * Time.deltaTime).magnitude);
        foreach(RaycastHit2D hit in hits)
        {
            if(!hit.transform.gameObject.GetComponent<ballDestroyer>())
            {   
             if (hit.collider != circlecollider && hit.transform.gameObject != lastobjecthit)
                {
                    lastobjecthit = hit.transform.gameObject;
                    velocity = Vector2.Reflect(velocity, hit.normal);

                    if(hit.transform.GetComponent<Paddle>())
                    {
                        velocity.y = Mathf.Abs(velocity.y);
                        gameController.audioController.PlayClip(OnPaddleHit);
                    }

                    if(hit.transform.GetComponent<Block>())
                    {
                        hit.transform.GetComponent<Block>().OnHit();
                    }
                    gameController.audioController.PlayClip(OnWallHit);
                }
            }

            else if(hit.transform.gameObject.GetComponent<ballDestroyer>())
            {
                lastobjecthit = hit.transform.gameObject;
            }
        }
    }
}