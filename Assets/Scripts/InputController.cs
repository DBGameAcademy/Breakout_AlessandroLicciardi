using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
   GameController gameController;
   Paddle paddle;

   private void Awake()
   {
       gameController = FindObjectOfType<GameController>();
       paddle = FindObjectOfType<Paddle>();
   }

   private void Update()
   {
       if (gameController.isPlaying && gameController.isPaused)
       {
           if(Input.anyKeyDown && !Input.GetMouseButton(0))
           {
               gameController.UnPauseGame();
           }
       }
       else if(gameController.isPlaying && !gameController.isPaused)
       {
           if (Input.GetKey(KeyCode.LeftArrow))
           {
               paddle.Move(Vector2.left);
           }
           if (Input.GetKey(KeyCode.RightArrow))
           {
               paddle.Move(Vector2.right);
           }
           
           if(Input.GetKeyDown(KeyCode.Escape))
           {
               gameController.PauseGame();
           }
       }
   }
}
