using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public CanvasController canvasController;

    public ArtifactIdentifier[] artifactIdentifiers;

    [Serializable]
    public class Artifact
    {
        public string name;
        public string date;
        public string location;
        public string material;
        public string description;
    }

    [Serializable]
    public class ArtifactList
    {
        public Artifact[] artifact;
    }

    public ArtifactList myArtifactList = new ArtifactList();
    
    // Start is called before the first frame update
    void Start()
    {
        myArtifactList = JsonUtility.FromJson<ArtifactList>(jsonFile.text);
        artifactIdentifiers = FindObjectsOfType<ArtifactIdentifier>();
    }

    public void GetActiveArtifact()
    {
        //get the active artifact
        foreach (ArtifactIdentifier artifactIdentifier in artifactIdentifiers)
        {
            if (artifactIdentifier.activeArtifact)
            {
                //get the artifact name
                string artifactName = artifactIdentifier.identifier;
                //find the artifact in the list
                foreach (Artifact artifact in myArtifactList.artifact)
                {
                    if (artifact.name == artifactName)
                    {
                        canvasController.UpdateCanvas(artifact.name, artifact.date, artifact.location, artifact.material, artifact.description);
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
