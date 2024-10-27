using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 20.0f;
    private Vector3 direction = Vector3.up;

    void Update()
    {
        //flyttar credits-texten så den syns över kameran
        transform.position += scrollSpeed * Time.deltaTime * direction;
    }
}
