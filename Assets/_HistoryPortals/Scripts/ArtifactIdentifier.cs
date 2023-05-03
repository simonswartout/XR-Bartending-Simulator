using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactIdentifier : MonoBehaviour
{
    public string identifier;

    public bool activeArtifact;

    void Start()
    {
        activeArtifact = false;
    }
}
