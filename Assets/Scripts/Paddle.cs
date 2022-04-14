using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float movespeed;

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * movespeed * Time.deltaTime, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * movespeed * Time.deltaTime, 0);
        }
    }
}
