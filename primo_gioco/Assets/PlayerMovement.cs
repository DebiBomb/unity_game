using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //  dichiarazioni
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Rigidbody2D rb;
    private float move;
    private int nJump = 0;
    private bool isRunning;

    void Awake()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    //  destra e sinistra
        move = Input.GetAxis("Horizontal");
        if(!isRunning){
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }else{
            rb.velocity = new Vector2(move * speed*2, rb.velocity.y);
        }
    //  salto
        if (Input.GetButtonDown("Jump") && nJump < 2){
            rb.AddForce(new Vector2(rb.velocity.x, jump)); 
            nJump ++;  
        }
    //  corsa  
        if (Input.GetKey(KeyCode.LeftShift)){
            isRunning = true; 
        }else{
            isRunning = false; 
        }              
    }

    //  metodo che controlla se sta saltando
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("Floor"))
            nJump = 0;       
    }
}