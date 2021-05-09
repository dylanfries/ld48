using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D playerRigid;


    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = playerRigid.velocity;
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // pump velocity and input axis into the animator
        anim.SetFloat("xVelocity", velocity.x);
        anim.SetFloat("yVelocity", velocity.y);
        anim.SetFloat("xInput", input.x);
        anim.SetFloat("yInput", input.y);
        // also jump, trigger is useful for transitioning. 
        anim.SetBool("jump", Input.GetButton("Jump"));
        if (Input.GetButtonDown("Jump"))
            anim.SetTrigger("jumpTrigger");

    }
}
