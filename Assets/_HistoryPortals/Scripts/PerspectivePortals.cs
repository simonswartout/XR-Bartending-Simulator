using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePortals : MonoBehaviour
{
    [SerializeField] Transform linkedPortalTeleportPoint;
    [SerializeField] Transform linkedPortalCamera;
    [SerializeField, Range(1, 180)] float directionalMagnitude = 10f;
    

    private void Update() {
        Vector3 dir = transform.InverseTransformPoint(Camera.main.transform.position);
        linkedPortalCamera.localRotation = Quaternion.LookRotation(dir);
        dir.z = 0;
        dir.x = Mathf.Clamp(dir.x, -0.2f, 0.2f);
        linkedPortalCamera.localPosition = -dir;
        //linkedPortalCamera.forward = -linkedPortalCamera.forward;
        // Vector3 localPos = linkedPortalCamera.localPosition;
        // localPos.z = dir.magnitude;
        // linkedPortalCamera.localPosition = localPos;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.position = linkedPortalTeleportPoint.position;
            other.transform.rotation = linkedPortalTeleportPoint.rotation;
        }
    }


}
