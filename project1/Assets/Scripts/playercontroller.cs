using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public GameObject BulletPrefab;
    public GameObject player1;
    public GameObject player2;
    public Transform bulletSpawn;
    public KeyCode fire;
    private float bulletTimer;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            //get direction
            Vector3 movement1 = new Vector3(Input.GetAxis("Horizontal1"), 0.0f, Input.GetAxis("Vertical1"));

            //rotate
            player1.transform.rotation = Quaternion.LookRotation(movement1);

            //move
            player1.transform.Translate(movement1 * speed * Time.deltaTime, Space.World);
            
        }


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))       
        {
            //get direction
            Vector3 movement2 = new Vector3(Input.GetAxis("Horizontal2"), 0.0f, Input.GetAxis("Vertical2"));

            //rotate
            player2.transform.rotation = Quaternion.LookRotation(movement2);

            //move
            player2.transform.Translate(movement2 * speed * Time.deltaTime, Space.World);
        }

        
        if (Input.GetKeyDown(fire) && Time.time >= bulletTimer)
        {
            //create bullet
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            //bullet velocity
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30.0f;

            //bullet cooldown
            bulletTimer = Time.time + 0.5f;
        }

        //tank cannot leave arena
        if (player1.transform.position.y < 0 || player1.transform.position.y > 10 || player1.transform.position.x < -25 || player1.transform.position.x > 25 || player1.transform.position.z < -25 || player1.transform.position.z > 25)
        {
            player1.transform.position = new Vector3(19.0f, 2f, -10f);
        }
        if (player2.transform.position.y < 0 || player2.transform.position.y > 10 || player2.transform.position.x < -25 || player2.transform.position.x > 25 || player2.transform.position.z < -25 || player2.transform.position.z > 25)
        {
            player2.transform.position = new Vector3(-10.0f, 2f, 14f);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            //move player1 when it gets hit
            if(this.gameObject == player1)
            {
                //Debug.Log("1");
                player1.transform.position = new Vector3(19.0f, 2f, -10f);
            }

            //move player2 when it gets hit
            if (this.gameObject == player2)
            {
                //Debug.Log("2");
                player2.transform.position = new Vector3(-10.0f, 2f, 14f);
            }
            
        }
        
    }
}
