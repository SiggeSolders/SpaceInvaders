using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public LineRenderer lineRendererTarget;
    LineRenderer lineR;

    BeatCounter checkBeatCounter;
    public GameObject beatConductor;

    public Missile missilePrefab;
    Missile missile;
    float speed = 5f;
    public int multiplier;

    private void Start()
    {
        lineR = lineRendererTarget.GetComponent<LineRenderer>();

        checkBeatCounter = beatConductor.GetComponent<BeatCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
        }

        Vector3 leftEdge = lineR.GetPosition(0);
        Vector3 rightEdge = lineR.GetPosition(3);

        position.x = Mathf.Clamp(position.x, leftEdge.x + 1, rightEdge.x - 1);

        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) && checkBeatCounter.inSync == true && checkBeatCounter.missleShot <= 0)
        {
            checkBeatCounter.missleShot = 2;
            missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
            if(multiplier <= 16)
            {
                multiplier = multiplier * 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && checkBeatCounter.inSync == true && checkBeatCounter.missleShot <= 0)
        {
            multiplier = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.OnPlayerKilled(this);
        }
    }
}
