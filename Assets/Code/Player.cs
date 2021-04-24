﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float xForce = 1f;
    public float yForce = 1f;
    public float jumpForce = 1f;

    public Vector2 joyInput = new Vector2();

    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateInput();
    }

    public void UpdateInput(){
        joyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigid.AddForce(new Vector2(joyInput.x * xForce, 0));

        if( Input.GetButtonDown("Jump")){
            rigid.AddForce(new Vector2( 0, yForce));
        }
    }

    
}