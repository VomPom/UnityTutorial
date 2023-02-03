using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp;

    public KeyCode moveDown;

    public float speed;
    
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            var y = speed * -1;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, y);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}