using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealPortal : MonoBehaviour
{
    [SerializeField] Vector3 originalScale;

    private void Awake() {
        originalScale = transform.localScale;
    }   
    public void OpenPortal() {
        //decrease the local scale of this object to 0 over time 
        StartCoroutine(OpenPortalRoutine());
    }

    IEnumerator OpenPortalRoutine() {
        float t = 0;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        while (t < 2) {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }
    }
}
