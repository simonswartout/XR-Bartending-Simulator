using System.Collections;
using System.Collections.Generic;
using BNG;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Transform canvasAnchorPoint;
    [SerializeField] JSONReader jsonReader;    
    [SerializeField] Text artifactName;
    [SerializeField] Text artifactDate;
    [SerializeField] Text artifactLocation;
    [SerializeField] Text artifactMaterial;
    [SerializeField] Text artifactDescription;
    
    public bool isFrozen = false;

    void Start()
    {
        HideCanvas();
    }

    public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }

    public void HideCanvas()
    {
        gameObject.SetActive(false);
    }

    public void FreezeCanvas()
    {
        if(isFrozen)
        {
            Debug.Log("Unfreezing Canvas");
            UnFreezeCanvas();
            return;
        }

        isFrozen = true;
        this.transform.parent = null;
    }

    public void UnFreezeCanvas()
    {
        //lerp the canvas back in front of the player camera and make it a child of the camera
        isFrozen = false;
        transform.parent = canvasAnchorPoint;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0, -90, 0);
    }

    public void UpdateCanvas(string artifactName, string artifactDate, string artifactLocation, string artifactMaterial, string artifactDescription)
    {
        this.artifactName.text = artifactName;
        this.artifactDate.text = artifactDate;
        this.artifactLocation.text = artifactLocation;
        this.artifactMaterial.text = artifactMaterial;
        this.artifactDescription.text = artifactDescription;
    }


    void Awake() {
        HideCanvas();
    }   

    void Update()
    {

    }



}
