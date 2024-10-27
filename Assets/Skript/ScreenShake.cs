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
        //Börjar med att hämta kamerans position
        Vector3 startPosition = transform.position;
        float elsapsedTime = 0f;
        
        while (elsapsedTime < duration)
        {
            elsapsedTime += Time.deltaTime;
            //skakar kameran utifrån strength variabeln och hur mycket tid det utspelas
            float strength = curve.Evaluate(elsapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        //Avslutar med att sätta tillbaka kameran till sin ursprungliga position
        transform.position = startPosition;
    }
}
