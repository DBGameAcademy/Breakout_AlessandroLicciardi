using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDestroyer : MonoBehaviour
{
   GameController gameController;

   private void Awake() 
   {

        gameController = FindObjectOfType<GameController>();   
   } 

   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if(collision.GetComponent<Ball>())
       {
        gameController.BallLost();
       }
   }
}
