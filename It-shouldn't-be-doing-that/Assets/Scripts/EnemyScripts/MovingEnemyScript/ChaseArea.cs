using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseArea : MonoBehaviour
{

    private EnemyMovement enemy;
    void Start()
    {
        enemy = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.chased = collision.gameObject;
            enemy.PlayerIsClose();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.chased = null;
            enemy.PlayerIsNotClose();
            

        }
    }

}
