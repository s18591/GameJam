using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LevelScript;

public class PhysicsChange : MonoBehaviour, IAttackable
{
    public void Attack()
    {
        Physics2D.gravity = new Vector2(Physics2D.gravity.x * -1, Physics2D.gravity.y * -1);
        TotalScript.Invert();
    }
}
