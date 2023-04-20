using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    [SerializeField] ParticleSystem pourParticles;
    [SerializeField] Color particleColor;

    [SerializeField] Transform containerFill;

    bool isEmptying = false;

    private void Start()
    {
        var main = pourParticles.main;
        main.startColor = particleColor;
    }
    
    private void Update() 
    {
        float dot = Vector3.Dot(transform.up, Vector3.up);
        Debug.Log(dot);

        if(Vector3.Dot(transform.up, Vector3.up) < 0.5)
        {
            Debug.Log("Pouring");
            pourParticles.Play();
        }
        else
        {
            if(pourParticles.isPlaying)
            {
                pourParticles.Stop();
            }
        }
    }

    // IEnumerator EmptyContainer()
    // {
    //     Debug.Log("Emptying container");
    //     yield return new WaitForEndOfFrame();
    //     while(Vector3.Dot(transform.up, Vector3.up) < 0.35) {
    //         containerFill.localScale -= new Vector3(0, 0.001f, 0) * Time.deltaTime;
    //         if(containerFill.localScale.y <= 0.1f)
    //         {
    //             containerFill.localScale = new Vector3(1, 0.1f, 1);
    //             break;
    //         }
    //         yield return new WaitForEndOfFrame();
    //     }
    // }
}