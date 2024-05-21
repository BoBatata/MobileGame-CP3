using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Transform iceBlockPosition;
    [SerializeField] private Transform SkyBlockPosition;

    [SerializeField] private GameObject iceBlockPrefab;
    [SerializeField] private GameObject skyBlockPrefab;

    private bool spawnBlock;
    private bool iceBlockSpawned;

    [SerializeField] private float spawnCooldown;
    private float elapsedTime;

    private void Start()
    {
        spawnBlock = true;
        iceBlockSpawned = false;
    }

    private void Update()
    {
        SpawnHandler();
    }

    private void SpawnHandler()
    {
        if (spawnBlock == true)
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= spawnCooldown)
        {
            SpawnRandom();
            elapsedTime = 0;
        }
    }

    private void SpawnRandom()
    {
        if (iceBlockSpawned == false)
        {
            iceBlockSpawned = true;
        }
        else if (iceBlockSpawned == true)
        {
            iceBlockSpawned = false;
        }

        if (iceBlockSpawned == false)
        {
            Instantiate(iceBlockPrefab, iceBlockPosition.position, iceBlockPosition.rotation);
        }
        else if (iceBlockSpawned == true)
        {
            Instantiate(skyBlockPrefab, SkyBlockPosition.position, SkyBlockPosition.rotation);
        }
    }
}
