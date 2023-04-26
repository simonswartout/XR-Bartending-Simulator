using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    [SerializeField] PlantGrowth plantGrowth;
    [SerializeField] ParticleSystem waterParticles;

    void FixedUpdate() {
        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 90) {
            plantGrowth.WaterPlant();
            waterParticles.Play();
        }
        else {
            waterParticles.Stop();
        }
    }
}
