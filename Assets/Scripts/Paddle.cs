using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float movespeed;
    public void Move(Vector2 _direction)
    {
        transform.Translate(_direction * movespeed * Time.deltaTime);
    }
}
