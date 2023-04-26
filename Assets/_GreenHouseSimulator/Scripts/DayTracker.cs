using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class DayTracker : MonoBehaviour
{
    [SerializeField] PlantGrowth plantGrowth;
    public int globalDayTracker = 0;
    //allow a button on the players remote to increment the day counter
    public void IncrementDayCounter()
    {
        globalDayTracker++;
        plantGrowth.IncrementDaysSincePlanting();
    }

    void Update() {
        if(InputBridge.Instance.AButton) {
            IncrementDayCounter();
        }
    }
}