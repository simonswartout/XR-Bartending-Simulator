using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Transform movementHandle;
    [SerializeField] GameObject Handle;
    [SerializeField] PlayerHandle playerHandle;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody rb;


    // Update is called once per frame
    void Update()
    {

    }

    void MoveWithHandle()
    {

    }

    
    void Jump()
    {
        Rigidbody handleRigidbody = Handle.GetComponent<Rigidbody>();
        if(Handle.isLocked && handleRigidbody.velocity.y > 10)
        {
            rb.AddForce(Vector3.up * handleRigidbody.velocity.y / 10, ForceMode.Impulse);
        }
    }

    void Dodge()
    {
        Rigidbody handleRigidbody = Handle.GetComponent<Rigidbody>();
        Vector3 localVelocity = transform.InverseTransformDirection(handleRigidbody.velocity);
        //the handle needs to rotate with the player

        if(Handle.isLocked && localVelocity.x > 10)
        {
            rb.AddForce(localVelocity.x * 2, ForceMode.Impulse);
        }
        else if(Handle.isLocked && localVelocity.x < -10)
        {
            rb.AddForce(localVelocity.x * 2, ForceMode.Impulse);
        }
        else if(Handle.isLocked && localVelocity.z > 10)
        {
            rb.AddForce(localVelocity.z * 2, ForceMode.Impulse);
        }
        else if(Handle.isLocked && localVelocity.z < -10)
        {
            rb.AddForce(localVelocity.z * 2, ForceMode.Impulse);
        }


    }
}
