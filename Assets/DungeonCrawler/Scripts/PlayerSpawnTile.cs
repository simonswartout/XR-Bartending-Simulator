using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnTile : MonoBehaviour
{
    [SerializeField] TilePiece tilePiece;
    [SerializeField] SetPlayerActiveState setPlayerActiveState;
    [SerializeField] PlayerHandle playerHandle;
    [SerializeField] ParticleSystem spawnParticleSystem;
    [SerializeField] Transform spawnPoint;

    void Update()
    {
        if(setPlayerActiveState.isActive)
        {
            return;
        }

        if(tilePiece.isSnapped)
        {
            StartCoroutine(SpawnPlayer());
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        setPlayerActiveState.SetActiveState(true);
        playerHandle.SetActiveState(true);
        setPlayerActiveState.GetComponent<Transform>().position = spawnPoint.position;
        playerHandle.GetComponent<Transform>().position = spawnPoint.position;
        spawnParticleSystem.Play();
    }
}
