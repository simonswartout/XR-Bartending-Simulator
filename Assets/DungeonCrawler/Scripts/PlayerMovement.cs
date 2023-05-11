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
            dir.x = 0;
            dir.z = 0;
            jumpCooldown = true;
            StartCoroutine(Jump());
        }
        else
        {
            dir.y = 0;

        }

        rb.velocity = dir * movementSpeed;
        rb.rotation = Quaternion.LookRotation(dir);
    }

    private IEnumerator Jump()
    {
        rb.velocity  = Vector3.up * 2f;
        yield return new WaitForSeconds(1f);
        jumpCooldown = false;
    }
}
