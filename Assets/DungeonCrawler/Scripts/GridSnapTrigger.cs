using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnapTrigger : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter MyMeshFilter;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        MyMeshFilter = GetComponent<MeshFilter>();
        meshRenderer.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {

        if(other.TryGetComponent(out TilePiece tilePiece))
        {
            if(tilePiece.isSnapped)
            {
                return;
            }

            

            meshRenderer.enabled = true;
            if(tilePiece.isReleased)
            {
                //set the tile piece equal in position, rotation, and scale to the grid snap trigger
                tilePiece.transform.position = this.transform.position;
                tilePiece.transform.rotation = transform.rotation;
                var RefSize = GetComponent<MeshFilter>().sharedMesh.bounds.size;
                var tileSize = tilePiece.GetComponent<MeshFilter>().sharedMesh.bounds.size;
                var newScale = new Vector3(RefSize.x / tileSize.x, RefSize.y / tileSize.y, RefSize.z / tileSize.z);

                tilePiece.transform.localScale = newScale;

                tilePiece.SetSnapped(true);
            }
            
            
        }
  
    }
    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out TilePiece tilePiece))
        {
            meshRenderer.enabled = false;
        }
    }
}
