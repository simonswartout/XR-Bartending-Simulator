using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class DuplicateOnGrab : MonoBehaviour
{
    [SerializeField] Grabbable grabbable;
    [SerializeField] Transform spawnPoint;

    private bool grabbed = false;

    private void Start() {
        grabbable = GetComponent<Grabbable>();
        Rigidbody rb = GetComponent<Rigidbody>();
        spawnPoint = transform;
    }

    private void Update() 
    {
        if(grabbable.BeingHeld)
        {
            grabbed = true;
        }

        if(grabbed = true && grabbable.BeingHeld == false)
        {
            Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);
            grabbed = false;
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.tag == "Player")
    //     {
    //         if(grabbable.BeingHeld)
    //         {
    //             GetComponent<Rigidbody>().isKinematic = true;
    //         }
    //         else
    //         {
    //             GetComponent<Rigidbody>().isKinematic = false;
    //         }
    //     }
    // }
}
