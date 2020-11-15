using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LevelScript;

public class Attack : MonoBehaviour, IAttackable
{

    void IAttackable.Attack()
    {
        GameObject.FindWithTag("Player").GetComponent<HP>().DecreaseHP();
    }


}
