using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Missile : Projectile
{
    private void Awake()
    {
        direction = Vector3.up;
    }
   
    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    void CheckCollision(Collider2D collision)
    {
        Bunker bunker = collision.gameObject.GetComponent<Bunker>();
        Walls walls = collision.gameObject.GetComponent<Walls>();

        if (bunker == null) //Om det inte är en bunker vi träffat så ska skottet försvinna.
        {
            Destroy(gameObject);
            //Om det träffade objektet inte är en vägg startas screenshake
            if(walls == null)
            {
                GameManager.Instance.StartShaking();
            }
        }
    }

}
