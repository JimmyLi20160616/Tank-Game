using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);//destory bullet when collision happens

        //destory Targets when hit it
        /*
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }*/
    }

    void Update()
    {
        //Bullets cannot leave the arena
        if (transform.position.y < 0|| transform.position.x < -25 || transform.position.x > 25 || transform.position.z < -25 || transform.position.z > 25)
        {
            Destroy(gameObject);
        }
    }
}
