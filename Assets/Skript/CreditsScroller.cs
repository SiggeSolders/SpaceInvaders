using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 20.0f;
    private Vector3 direction = Vector3.up;
    // Update is called once per frame
    void Update()
    {
        transform.position += scrollSpeed * Time.deltaTime * direction;
    }
}
