using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    
class CharacterFlip : MonoBehaviour
{

        private bool isNormalRotation;
        public void Start()
        {
            isNormalRotation = TotalScript.GetGravity();
        }

        public void  Update()
        {
            if (isNormalRotation != TotalScript.GetGravity())
            {
                isNormalRotation = TotalScript.GetGravity();
                TotalScript.GravityFlip(gameObject);
            }
        }
}

