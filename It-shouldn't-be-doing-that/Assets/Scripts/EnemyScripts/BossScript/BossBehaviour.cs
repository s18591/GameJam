using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float shootCount = 100;
    private float shootCounter = 0;
    public float delay = 15;
    private float timer = 0;

    public float angle = 1;
    public float angleDelay = 10;
    private float angleCounter = 0;

    private bool forward = true;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay) {
           /* transform.Rotate(0.0f, angle, 0.0f, Space.Self);
            angleCounter++;*/
            /*if (angleCounter > angleDelay)
            {
                angleCounter = 0;*/
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 180;
                Instantiate(GetComponentInParent<CharacterThrow>().projectile, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z), transform.rotation);
                shootCounter++;
           // }

            /*if (forward)
                angle++;
            else
                angle--;


            if (angle >= 180)
                forward = true;
            else if (angle <= 0)
                forward = false;*/

            if (shootCounter >= shootCount)
            {
                timer = 0;
                shootCounter = 0;
            }
        }
    }





}
