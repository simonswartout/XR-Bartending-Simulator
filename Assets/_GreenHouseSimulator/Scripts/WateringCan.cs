using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class WateringCan : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticles;

    private float lastRotation = 0f;

    void Update() {
        if(InputBridge.Instance.RightTrigger == 1f) {
            waterParticles.Play();
        }
        else {
            waterParticles.Stop();
        }
    }
}
