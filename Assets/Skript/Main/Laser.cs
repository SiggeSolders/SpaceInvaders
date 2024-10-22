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

        Destroy(gameObject); //s� fort den krockar med n�got s� ska den f�rsvinna.
        if (walls == null)
        {
            GameManager.Instance.StartShaking();
        }
    }
}
