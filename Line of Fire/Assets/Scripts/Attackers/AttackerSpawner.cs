using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 0f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Spawn(Random.Range(0, attackers.Length));
    }

    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate
            (attackers[index], transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }
}
