using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public string NextLevel;  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (NextLevel != null && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
