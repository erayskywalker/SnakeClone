using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputs : MonoBehaviour
{
    [SerializeField] SnakeController _snake;

    bool up, down, left, right = true;

    public void Up()
    {
        if (!down)
        {
            _snake._direction = Vector2.up;
            up = true; down = false; left = false; right = false;
        }
    }

    public void Down()
    {
        if (!up)
        {
            _snake._direction = Vector2.down;
            up = false; down = true; left = false; right = false;
        }
    }

    public void Left()
    {
        if (!right)
        {
            _snake._direction = Vector2.left;
            up = false; down = false; left = true; right = false;
        }
    }

    public void Right()
    {
        if (!left)
        {
            _snake._direction = Vector2.right;
            up = false; down = false; left = false; right = true;
        }
        

    }
}
