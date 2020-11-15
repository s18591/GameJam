using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator animator;
    bool isDoorOpen;
    void Start()
    {
        isDoorOpen = false;
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isDoorOpen = true;
            DoorControl("Open");
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (isDoorOpen)
        {
            isDoorOpen = false;
            DoorControl("Close");
        }
    }
    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);
    }

}
