
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;
    public float speed = 200;
    bool isFacingRigth =  true;
    public Rigidbody2D PlayerRB;
    public Animator animator;

    public  float jumpForce = 14;
    bool isGrunded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    int numberofJumps = 0;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx => 
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrunded = Physics2D.OverlapCircle(groundCheck.position,0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrunded);
        //Debug.Log(isGrunded);
        PlayerRB.velocity = new Vector3(direction * speed * Time.fixedDeltaTime, PlayerRB.velocity.y,0);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRigth && direction <0 || !isFacingRigth && direction >0)
            Flip();
    }
    void Flip()
    {
        isFacingRigth = !isFacingRigth;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    // Metodo para el salto del player(doble salto)

    void Jump()
    {
        if(isGrunded)
        {
            numberofJumps = 0;
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpForce);
            numberofJumps++;
        }
        else
        {
            if(numberofJumps == 1)
            {
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpForce);
                numberofJumps++;
            }
        }
            
    }
}
