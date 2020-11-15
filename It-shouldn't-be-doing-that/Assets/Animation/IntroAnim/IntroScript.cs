using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Next", 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Next()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
