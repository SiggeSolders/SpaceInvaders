using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float duration = 1f;
    public AnimationCurve curve;
    void Update()
    {

    }
     public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elsapsedTime = 0f;

        while (elsapsedTime < duration)
        {
            elsapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elsapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
