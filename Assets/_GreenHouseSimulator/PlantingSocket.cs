using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PlantingSocket : MonoBehaviour
{
    [SerializeField] DigDirtTrigger digDirtTrigger;
    [SerializeField] Transform plantingPosition;

    //I need this script to be a custom socket interactor 
    //I need to be able to grab the plant and move it around
    //I need to be able to drop the plant into the socket
    //I need to be able to pick the plant back up
    //I need to be able to reset the dirt
    //I need to be able to reset the plant
    //I need to be able to reset the socket

    void Start()
    {
        digDirtTrigger = GetComponentInParent<DigDirtTrigger>();
        plantingPosition = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plant")
        {
            if(!digDirtTrigger.dugToPlantingDepth)
            {
                Destroy(other.gameObject);  
                return;
            }

            other.transform.position = plantingPosition.position;
            other.transform.rotation = plantingPosition.rotation;
            //freeze position and rotation of the plant 
            other.gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //freeze position and rotation of the socket
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }


}
