using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    PlantGrowth plantGrowth;

    private void OnParticleCollision(GameObject other) {
        if(other.gameObject.tag == "Plant")
        {
            plantGrowth = other.gameObject.GetComponent<PlantGrowth>();
            plantGrowth.WaterPlant();
        }
    }
}
