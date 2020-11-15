using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class TotalScript : MonoBehaviour
{
    private static bool isGravityNorm;

    public static TotalScript Instance
    {
        get;
        set;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Instance = this;
    }


    public static int HPCount = 3;


    public void Start()
    {
        isGravityNorm = true;
    }

    public static void Invert() 
    {
        isGravityNorm = !isGravityNorm;
    }

    public static bool GetGravity()
    {
        return isGravityNorm;
    }


    public static void GravityFlip(GameObject gameObject)
    {
        //gameObject.transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * -1, gameObject.transform.localScale.z);
    }
}
