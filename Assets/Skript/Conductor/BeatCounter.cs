using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;

public class BeatCounter : MonoBehaviour
{
    private float songPos;
    [SerializeField]
    private double songPosRoundedUp;
    private double songPosRoundedDown;

    public bool inSync;
    [SerializeField]
    public int missleShot;

    [SerializeField]
    int roundedUpValue;

    public GameObject conductor;
    ConductorScript beatConductor;


    private void Awake()
    {
        roundedUpValue = 4;
    }
    // Start is called before the first frame update
    void Start()
    {
        //roundedUpValue = 1;
        beatConductor = conductor.GetComponent<ConductorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //uppdaterar låt positionen
        songPos = beatConductor.songPositionInBeats;
        songPosRoundedUp = Math.Ceiling(songPos);
        songPosRoundedDown = Math.Floor(songPos);

        //kollar om låten är vid en beat
        if(songPosRoundedUp - songPos <= 0.2 && songPosRoundedUp - songPos >= 0)
        {
            inSync = true;
        }
        else if(songPosRoundedDown - songPos >= -0.2 && songPosRoundedDown - songPos <= 0)
        {
            inSync = true;
        }
        else
        {
            inSync = false;
        }

        //minskar missileShot och ökar roundedUpValue
        if(roundedUpValue == songPosRoundedUp)
        {
            roundedUpValue += 1;
            missleShot -= 1;
        }
        
    }
}
