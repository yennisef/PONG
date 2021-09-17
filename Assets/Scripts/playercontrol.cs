﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode downButton = KeyCode.S;
    public KeyCode upButton = KeyCode.W;

    public float speed = 10.0f;

    public float yBoundary = 9.0f;

    private Rigidbody2D rigidBody2D;

    private int score;

    //titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;

    //untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;

        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0.0f;
        }

        rigidBody2D.velocity = velocity;

        Vector3 position = transform.position;

        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;
    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int Score
    {
        get { return score; }
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}