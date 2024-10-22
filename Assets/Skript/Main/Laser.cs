using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Projectile
{
    private void Awake()
    {
        direction = Vector3.down;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Walls walls = collision.gameObject.GetComponent<Walls>();

        Destroy(gameObject); //så fort den krockar med något så ska den försvinna.
        if (walls == null)
        {
            GameManager.Instance.StartShaking();
        }
    }
}
