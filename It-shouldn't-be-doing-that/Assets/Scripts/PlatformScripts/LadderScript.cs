using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("IsOnLadderUp", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);


        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))

        {
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("IsOnLadderDown", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);


        }
        else
        {

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("IsOnLadderUp", false);
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("IsOnLadderDown", false);

        }
    }
}
