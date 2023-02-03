using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Ball")
        {
            var wallName = transform.name;
            GameManager.Score(wallName);
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            col.gameObject.SendMessage("ResetBall");
        }
    }
}