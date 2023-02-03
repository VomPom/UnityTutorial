using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100;

    void Start()
    {
        StartCoroutine(ExampleCoroutine(2));
    }

    private IEnumerator ExampleCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        GoBall();
    }

    void ResetBall()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        StartCoroutine(ExampleCoroutine(2.0f));
        gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.CompareTag("Player"))
        {
            // Debug.Log("--julis it's worked.");
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.5f, 1.5f);
            audioSource.Play();
        }
    }

    void GoBall()
    {
        var randomNumber = Random.Range(0, 2);
        gameObject.GetComponent<Rigidbody2D>()
            .AddForce(randomNumber <= 0.5 ? new Vector2(ballSpeed, 10) : new Vector2(-ballSpeed, -10));
    }

    void Update()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody2D>();
        var xVel = rigidbody.velocity.x;
        if (xVel < 18 && xVel > -18 && xVel != 0)
        {
            if (xVel > 0)
            {
                rigidbody.velocity = new Vector2(20, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(-20, rigidbody.velocity.y);
            }
        }
    }
}