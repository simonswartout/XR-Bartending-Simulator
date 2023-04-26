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

    [SerializeField] int timesWatered = 0;
    [SerializeField] int daysWithoutWater = 0;
    [SerializeField] int daysSincePlanting = 0;
    [SerializeField] int daysToFruit = 7;

    void Start() {
        SetLifeStage(LifeStage.Seedling);
        SetWaterStatus(WaterStatus.Dry);
    }

    public void SetLifeStage(LifeStage newLifeStage) {
        lifeStage = newLifeStage;
    }
    
    public void SetWaterStatus(WaterStatus newWaterStatus) {
        waterStatus = newWaterStatus;
    }

    public void WaterPlant() {

        if(waterStatus == WaterStatus.Watered) return;

        if(lifeStage == LifeStage.Dead) return;
        
        timesWatered++;
        daysWithoutWater = 0;
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
        
        if(timesWatered >= 6) {
            SetLifeStage(LifeStage.Fruit);
        }
    }

    public void IncrementDaysWithoutWater() {
        daysWithoutWater++;
        daysToFruit ++;
        
        if(daysWithoutWater >= 3) {
            SetLifeStage(LifeStage.Withered);
        }

        else if(daysWithoutWater >= 5) {
            SetLifeStage(LifeStage.Dead);
        }
    }

    public void IncrementDaysSincePlanting() {
        if(waterStatus == WaterStatus.Dry) IncrementDaysWithoutWater();
        daysSincePlanting++;
        SetWaterStatus(WaterStatus.Dry);
    }
}
