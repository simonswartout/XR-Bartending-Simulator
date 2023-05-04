using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePortals : MonoBehaviour
{
    [SerializeField] Transform linkedPortalTeleportPoint;
    [SerializeField] Transform linkedPortalCamera;
    

    private void Update() {
        Vector3 dir = transform.position - Camera.main.transform.position;
        linkedPortalCamera.localRotation = Quaternion.LookRotation(dir, Vector3.up);
        linkedPortalCamera.forward = -linkedPortalCamera.forward;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.position = linkedPortalTeleportPoint.position;
            other.transform.rotation = linkedPortalTeleportPoint.rotation;
        }
    }
}
