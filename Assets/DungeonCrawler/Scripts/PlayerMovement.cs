using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Transform movementHandle;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody rb;


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = movementHandle.position - transform.position;
        dir.y = 0;
        rb.velocity = dir * movementSpeed;
        rb.rotation = Quaternion.LookRotation(dir);
    }
}
