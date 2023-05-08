using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Vector3 offset;
    [SerializeField] ParticleSystem connectingEffect;
    public bool isHeld = false;

    public void SetHeld(bool held)
    {
        isHeld = held;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void isReleased()
    {
        isHeld = false;
        connectingEffect.Play();
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

        if(Vector3.Distance(transform.position, player.position + offset) < 0.1f)
        {
            connectingEffect.Stop();
        }
    }
}
