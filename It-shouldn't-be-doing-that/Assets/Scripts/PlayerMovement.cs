using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 200;
    public float runSpeed = 500;
    public float jumpForce = 300;
    
    public float dashStep = 1;


    public GameObject dashEffect;
    private Rigidbody2D rb;
    private float xScale;


    private bool isRunning;
    private bool isGrounded;
    private bool isDoubleJump;
    private bool isDashing;

    public Animator animator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isRunning = false;
        isDashing = false;
        
        isGrounded = true;
        isDoubleJump = false;

        xScale = transform.localScale.x;
    }

    void Update()
    {
            
            RunningCheck();
            WalkAndRun();
            CharacterFlip();
            Jump();
            DashCheck();
            Dash();
            
        
    }
    private void RunningCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    private void WalkAndRun() 
    {
        float xDisplacement;

        if (isRunning)
        {
            xDisplacement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            animator.SetFloat("Speed", Mathf.Abs(xDisplacement));
        }
        else
        {
            xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(xDisplacement));
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDoubleJump)
        {
            Debug.Log(TotalScript.GetGravity());
            if (!TotalScript.GetGravity())
            {
                rb.AddForce(new Vector2(0, jumpForce));
                animator.SetBool("IsJump", true);
                animator.SetBool("IsOnLadderUp", false);
                animator.SetBool("IsOnLadderDown", false);
            }
            else
            {
                rb.AddForce(new Vector2(0, -jumpForce));
                animator.SetBool("IsJump", true);
                animator.SetBool("IsOnLadderUp", false);
                animator.SetBool("IsOnLadderDown", false);
            }
            if (isGrounded == false) isDoubleJump = true;
            isGrounded = false;
        }
    }

    private void DashCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isDashing = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            isDashing = false;
        }
    }

    private void Dash()
    {
        if (isDashing) 
        {
            Vector2 dash = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * dashStep, rb.position.y);
            if(dashEffect != null)
            Instantiate(dashEffect, new Vector3(transform.position.x,transform.position.y,-1), Quaternion.identity);
            
            rb.MovePosition(dash);
        }
    }

    public void CharacterFlip() 
    {

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") >= 0)
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        isDoubleJump = false;
        animator.SetBool("IsJump", false);
        animator.SetBool("IsOnLadderUp", false);
        animator.SetBool("IsOnLadderDown", false);
        if (col.gameObject.tag == "DisapearPlatform")
        {

            col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Destroy(col.gameObject,1);
        }


    }

}
