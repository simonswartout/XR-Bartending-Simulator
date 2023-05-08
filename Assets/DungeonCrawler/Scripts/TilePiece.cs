using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePiece : MonoBehaviour
{
    Rigidbody rb;
    public bool isSnapped = false;
    public bool isReleased = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isSnapped = false;
        isReleased = false;
    }
    
    public void SetSnapped(bool snapped)
    {
        isSnapped = snapped;
        rb.isKinematic = snapped;
    }
    public void SetReleased(bool released)
    {
        isReleased = released;
    }

    void Update()
    {
        if(isSnapped)
        {
            rb.isKinematic = false;
            //ignore collisions with other tile pieces to prevent snapping to the wrong piece 
            //when the player is moving the tile piece
        }
        IgnoreTilePieceCollisions();
    }

    void IgnoreTilePieceCollisions()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent(out TilePiece tilePiece))
            {
                Physics.IgnoreCollision(collider, GetComponent<Collider>());
            }
        }
    }

}
