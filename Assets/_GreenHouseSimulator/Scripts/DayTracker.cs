using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class DayTracker : MonoBehaviour
{
    public int globalDayTracker = 0;
    public bool cooldown = false;
    //allow a button on the players remote to increment the day counter

    void Start()
    {
        IncrementDayCounter();
        Debug.Log("Day " + globalDayTracker);
    }
    public IEnumerator IncrementDayCounter()
    {
        yield return new WaitForSeconds(1);
        globalDayTracker++;
        cooldown = false;
    }

    //on player remote button press increment the day counter but only once per day
    void Update()
    {
        if(cooldown == true) return;

        if (InputBridge.Instance.AButton) 
        {
            StartCoroutine(IncrementDayCounter());
            cooldown = true;
        }
    }

}