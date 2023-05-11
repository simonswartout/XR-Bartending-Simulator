using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Transform movementHandle;
    [SerializeField] PlayerHandle playerHandle;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody rb;
    private bool jumpCooldown = false;


    // Update is called once per frame
    void Update()
    {
        MoveWithHandle();
    }

    void MoveWithHandle()
    {
        if(jumpCooldown)
        {
            return;
        }
        Vector3 dir = movementHandle.position - transform.position;

        if(dir.y > .5f)
        {
            StartCoroutine(Jump());
        }
        else
        {
            dir.y = 0;
        }

        Vector3 targetVelocity = dir * movementSpeed;
        targetVelocity.y = rb.velocity.y;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 100f * Time.deltaTime);
        
        if(dir.y != 0) return;
        rb.rotation = Quaternion.LookRotation(dir);

    }

    private IEnumerator Jump()
    {
        jumpCooldown = true;
        rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        jumpCooldown = false;
    }
}
