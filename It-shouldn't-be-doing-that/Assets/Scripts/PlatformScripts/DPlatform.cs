using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlatform : MonoBehaviour
{
    // Start is called before the first frame update
   void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject, 5f);
        }
    }
}
