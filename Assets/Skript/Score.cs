using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigidbody;
    public int Objectvalue = 1;
    public ScoreManager sm;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Invader")
        {
            ScorePickup inventory = other.GetComponent<ScorePickup>();

            if (inventory != null)
            {
                inventory.objects = inventory.objects + Objectvalue;
               
                //sm.ScoreCount++;
                sm.UpdateScore();
            }
        }
    }
}
