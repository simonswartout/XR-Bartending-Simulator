using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigDirtTrigger : MonoBehaviour
{

    Transform originalTransform;

    [SerializeField] float plantingDepth = 0.3f;
    [SerializeField] bool dugToPlantingDepth = false;
    [SerializeField] bool planted = false;

    private void Start() {
        originalTransform = transform;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Trowel")
        {
            if(dugToPlantingDepth) return;

            //if the velocity of the trowel is greater than 0.5, then scale the dirts y value down
            if(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2f)
            {
                Debug.Log("Trowel velocity is greater than 0.5");
                //scale the dirts y value down
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - plantingDepth, transform.localScale.z);
                dugToPlantingDepth = true;
            }
        }
    }

    public void ResetDirt()
    {
        transform.localScale = originalTransform.localScale;
    }
}
