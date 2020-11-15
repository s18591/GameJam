using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Characteristics")]
    public float speed = 1;
    public float chaseSpeed = 2;
    [Header("Patroling points")]
    public GameObject LeftmostPoint;
    public GameObject RightmostPoint;
    private GameObject destination;

    private bool isGoingRight;

    [HideInInspector]
    public GameObject chased = null;

    private Rigidbody2D rb;

    void Start()
    {
        destination = RightmostPoint;
        rb = GetComponent<Rigidbody2D>();

        isGoingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (chased == null)
        {
            if(RightmostPoint != null && LeftmostPoint != null)
            Move();
        }
        else
        {
            Chase();
        }
    }

    private void Move()
    {

       
        if (isGoingRight)
        {
            destination = RightmostPoint;
        }
        else
        {
            destination = LeftmostPoint;
        }

        Vector2 direction = (Vector2)destination.transform.position - (Vector2)transform.position;
        direction.Normalize();
        Flip(direction.x);


        float xDisplacement = direction.x * speed;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        float unitDirX;
        unitDirX = destination.transform.position.x - rb.position.x;
        if ( Mathf.Abs(unitDirX) <= 0.2)
        {
            isGoingRight = !isGoingRight;
        }
    }

    private void Chase()
    {

        Vector2 direction = (Vector2)chased.transform.position - (Vector2)transform.position;
        direction.Normalize();
        if (direction.x > 0)
            Flip(Mathf.Abs(transform.localScale.x));
        else
            Flip(Mathf.Abs(transform.localScale.x)*-1);

        float xDisplacement = direction.x * chaseSpeed;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

    }


    private void Flip(float x)
    {
        transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
    }


    public void PlayerIsClose()
    {

    }

    public void PlayerIsNotClose()
    {

    }

    public void PlayerInAttackArea()
    {

    }

    public void PlayerOutOfAttackArea()
    {

    }

}
