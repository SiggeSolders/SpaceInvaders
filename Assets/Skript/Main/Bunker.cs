using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bunker : MonoBehaviour
{
    int nrOfHits = 0;
    SpriteRenderer spRend;
    private AudioSource hit;
    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
        hit = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            hit.Play();
            //Ändrar färgen beroende på antal träffar.
            nrOfHits++;
            Color oldColor = spRend.color;

            Color newColor = new Color(oldColor.r +(nrOfHits*0.1f), oldColor.g + (nrOfHits * 0.1f), oldColor.b + (nrOfHits * 0.1f));
            
            spRend.color = newColor;
            
            if (nrOfHits == 4)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetBunker()
    {
        gameObject.SetActive(true);
    }
}
