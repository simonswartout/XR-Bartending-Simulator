using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Transform canvasAnchorPoint;
    
    public bool isFrozen = false;

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

    void Awake() {
        HideCanvas();
    }   

    void Update()
    {

    }


}
