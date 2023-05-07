using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Vector3 offset;
    public bool isHeld = false;

    public void SetHeld(bool held)
    {
        isHeld = held;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, player.position + offset, movementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, movementSpeed * Time.deltaTime);
    }
}
