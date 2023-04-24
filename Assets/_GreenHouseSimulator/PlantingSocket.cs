using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PlantingSocket : MonoBehaviour
{
    [SerializeField] DigDirtTrigger digDirtTrigger;
    [SerializeField] Transform plantingPosition;

    private void Start() {
        GetComponent<Renderer>().material = null;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Plant")
        {
            Debug.Log("Plant entered planting socket");
            other.gameObject.transform.position = plantingPosition.position;
            other.gameObject.transform.rotation = plantingPosition.rotation;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            digDirtTrigger.ResetDirt();
        }
    }
}
