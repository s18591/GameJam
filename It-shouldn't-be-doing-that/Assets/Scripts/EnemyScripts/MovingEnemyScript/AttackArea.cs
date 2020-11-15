using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LevelScript;

public class AttackArea : MonoBehaviour
{
    private IAttackable attackable;
    
    private EnemyMovement enemy;
    public float attackDelay;
    private float timer;
    private bool isOnCooldown;

    [Header("To show cooldown")]
    public GameObject coolDownObject;
    [Header("To create shield")]
    public GameObject shield;
    public GameObject image;

    void Start()
    {
        enemy = GetComponentInParent<EnemyMovement>();
        attackable = GetComponentInParent<IAttackable>();
        attackDelay = 20;
        timer = 0;
        isOnCooldown = false;
    }


    private void Update()
    {
        if (shield != null && !TotalScript.GetGravity())
        {
            shield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        else if (shield != null && TotalScript.GetGravity())
        {
            shield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if(isOnCooldown)
        {
            timer += Time.deltaTime;
            if (timer >= attackDelay)
            {
                timer = 0;
                isOnCooldown = false;
                if (coolDownObject != null)
                    coolDownObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(image);
        if (collision.gameObject.CompareTag("Player"))
        {
            if(enemy != null)
                enemy.PlayerInAttackArea();
            if (!isOnCooldown)
            {
                attackable.Attack();
                if(coolDownObject != null)
                    coolDownObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                isOnCooldown = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (enemy != null)
                enemy.PlayerOutOfAttackArea(); 
        }
    }
}
