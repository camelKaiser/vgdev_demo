using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    GameObject timerobject;
    TimerController thescript;
    public float speed = 0;
    private Rigidbody rb; 
    private int count;
    private float movementX;
    private float movementY;

    public GameObject winTextObject;
    public GameObject loseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timerobject = GameObject.Find("Timer");
        thescript = timerobject.GetComponent<TimerController>();

        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // Function Body
        Debug.Log("Trying to move " + movementValue.ToString());
        Vector2 movementVector = movementValue.Get<Vector2>(); 

        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

 
    void OnTriggerEnter(Collider other)
    {
        if (!thescript.gameover){
            if (!thescript.isday && other.gameObject.CompareTag("Finish"))
            {
                Debug.Log("hit the goal");
                winTextObject.SetActive(true);
                thescript.gameover = true;
                thescript.win = true;
            
            } else if (!thescript.isday && other.gameObject.CompareTag("Enemy")) {
                loseTextObject.SetActive(true);
                thescript.gameover = true;
                thescript.win = false;
            }
            
        }


    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 

      
    }

}
