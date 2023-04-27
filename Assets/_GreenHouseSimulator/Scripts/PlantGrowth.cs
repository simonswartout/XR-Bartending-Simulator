using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public enum LifeStage {
        Seedling,
        Growing,
        Mature,
        Flower,
        Fruit,
        Withered,
        Dead
    }

    public enum WaterStatus {
        Dry,
        Watered
    }

    public LifeStage lifeStage;
    public WaterStatus waterStatus;
    public DayTracker dayTracker;

    //get the child gameobjects of the plant that will serve as the different growth stages
    [SerializeField] GameObject seedling;
    [SerializeField] GameObject growing;
    [SerializeField] GameObject mature;
    [SerializeField] GameObject flower;


    [SerializeField] int timesWatered = 0;
    [SerializeField] int daysWithoutWater = 0;
    [SerializeField] int daysSincePlanting = 0;
    [SerializeField] int daysToFruit = 7;

    void Start() {
        SetLifeStage(LifeStage.Seedling);
        SetWaterStatus(WaterStatus.Dry);

        dayTracker = GameObject.Find("GameTimeManager").GetComponent<DayTracker>();
    }

    public void SetLifeStage(LifeStage newLifeStage) {
        lifeStage = newLifeStage;
    }
    
    public void SetWaterStatus(WaterStatus newWaterStatus) {
        waterStatus = newWaterStatus;
    }

    public void WaterPlant() {

        Debug.Log("WateringPlant");

        if(waterStatus == WaterStatus.Watered) return;

        if(lifeStage == LifeStage.Dead) return;
        
        timesWatered++;
        SetWaterStatus(WaterStatus.Watered);
        

        if(timesWatered >= 2) {
            SetLifeStage(LifeStage.Growing);
        }
        
        if(timesWatered >= 4) {
            SetLifeStage(LifeStage.Mature);
        }
        
        if(timesWatered >= 5) {
            SetLifeStage(LifeStage.Flower);
        }
        
    }

    public void IncrementDaysSincePlanting() {
        if(daysSincePlanting != dayTracker.globalDayTracker) {
            daysSincePlanting++;
            SetWaterStatus(WaterStatus.Dry);
        }
    }

    void Update()
    {
        IncrementDaysSincePlanting();

        if(lifeStage == LifeStage.Seedling) {
            seedling.SetActive(true);
            growing.SetActive(false);
            mature.SetActive(false);
            flower.SetActive(false);
        }
        else if(lifeStage == LifeStage.Growing) {
            seedling.SetActive(false);
            growing.SetActive(true);
            mature.SetActive(false);
            flower.SetActive(false);
        }
        else if(lifeStage == LifeStage.Mature) {
            seedling.SetActive(false);
            growing.SetActive(false);
            mature.SetActive(true);
            flower.SetActive(false);
        }
        else if(lifeStage == LifeStage.Flower) {
            seedling.SetActive(false);
            growing.SetActive(false);
            mature.SetActive(false);
            flower.SetActive(true);
        }
    }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag == "Water") {
    //         WaterPlant();
    //     }
    // }
}


