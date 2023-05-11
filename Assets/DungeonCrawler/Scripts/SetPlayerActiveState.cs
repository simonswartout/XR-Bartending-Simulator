using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerActiveState : MonoBehaviour
{
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveState(bool state)
    {
        gameObject.SetActive(state);
        isActive = state;
    }
}
