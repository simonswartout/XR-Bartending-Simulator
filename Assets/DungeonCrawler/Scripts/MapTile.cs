using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField] TilePiece tilePiece;
    private void Start() 
    {        
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            //if it is the mesh renderer of this game object, skip it
            if(meshRenderer.gameObject == this.gameObject)
            {
                continue;
            }
            meshRenderer.enabled = false;
        }
    }

    private void Update() 
    {
        if(tilePiece.isSnapped)
        {
            foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.enabled = true;
            }
        }    
    }



    
}
