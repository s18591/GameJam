using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [Header("Moving characteristics")]
    public float velocity = 10;
    [Header("Tag to damage")]
    public string damageTag = "Player";
    [Header("TimeToDestroy")]
    public float destrTime = 10;

    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * -1 * velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(damageTag))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<HP>().DecreaseHP();
        }
        Destroy(gameObject,destrTime);
    }
}
