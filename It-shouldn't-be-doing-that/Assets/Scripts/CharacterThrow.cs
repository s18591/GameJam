using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterThrow : MonoBehaviour
{
    [Header("Is it a player character")]
    public bool isPlayerCharacter;
    [Header("Is a character able to throw")]
    public bool isThrowing = true;
    [Header("Projectile to shoot")]
    public GameObject projectile;
    [Header("NPC shoot delay")]
    public float delay = 2;
    private float timer = 0;


    // Update is called once per frame
    void Update()
    {
        if (isThrowing && isPlayerCharacter)
        {

            timer += Time.deltaTime;
            if (timer >= delay)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                GetComponent<HP>().DecreaseHP();
                    timer = 0;
                 }
            }
        }
        else if (isThrowing && !isPlayerCharacter)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    public void LetOut(Quaternion rot)
    {
            Instantiate(projectile, transform.position,rot);
    }


    public void Shoot()
    {

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 180;
        Instantiate(projectile, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z), Quaternion.Euler(rotationVector));

    }

    public void LetOut()
    {
        Debug.Log(transform.localScale.x + "  0 ");
        if (transform.localScale.x < 0)
        {
            Debug.Log(transform.localScale.x + "  1 ");
            //Instantiate(projectile, transform.position, transform.rotation);
            Instantiate(projectile, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z), transform.rotation);
        }
        else
        {
            Debug.Log(transform.localScale.x + "  2 ");
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = 180;
            Instantiate(projectile, new Vector3(transform.position.x + 0.3f,transform.position.y,transform.position.z), Quaternion.Euler(rotationVector));
        }
    }
}
