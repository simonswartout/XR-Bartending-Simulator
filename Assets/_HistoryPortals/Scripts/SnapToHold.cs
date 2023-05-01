using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class SnapToHold : MonoBehaviour
{
    [SerializeField] bool isReleased = false;
    [SerializeField] bool isFrozen = false;
    [SerializeField] bool freezeRotationZ = false;
    [SerializeField] bool freezeRotationY = false;
    [SerializeField] Grabbable grabbable;
    [SerializeField] Transform startingTransform;   
    [SerializeField] CanvasController canvasController;
    [SerializeField] JSONReader jsonReader;
    ArtifactIdentifier artifactIdentifier;
    Rigidbody rb;

    void Start()
    {
        grabbable = GetComponent<Grabbable>();
        startingTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        artifactIdentifier = GetComponentInParent<ArtifactIdentifier>();
    }
    void FreezePosition()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }
    
    void UnFreezePosition()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    void FreezeRotationZ()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        freezeRotationZ = true;
        freezeRotationY = false;
    }

    void FreezeRotationY()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        freezeRotationZ = false;
        freezeRotationY = true;
    }


    void Update()
    {
        if(grabbable.BeingHeld)
        {
            isReleased = false;
            isFrozen = false;
            artifactIdentifier.activeArtifact = false;
            UnFreezePosition();
            canvasController.HideCanvas(); 
        }
        
        if(rb.velocity.magnitude > 1f && !grabbable.BeingHeld)
        {
            isReleased = true;
            
        }

        if(isReleased && !isFrozen)
        {
            FreezePosition();
            isFrozen = true;
            artifactIdentifier.activeArtifact = true;
            jsonReader.GetActiveArtifact();
            
            
        }

        if(isFrozen) 
        {
            canvasController.ShowCanvas();
            //if the right trigger is pressed 
        }
    }
}
