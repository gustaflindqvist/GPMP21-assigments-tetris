using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] groups;

    void Start()
    {
        SpawnNext();
    }

    private void SpawnNext()
    {
        var randomIndex = Random.Range(0, groups.Length);
        // Spawn group at current position and rotation
        Instantiate(groups[randomIndex], transform.position, Quaternion.identity);
    }
}
