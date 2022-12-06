using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //  dichiarazioni
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private float move;

    void Awake()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    //  destra e sinistra
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

    }
}