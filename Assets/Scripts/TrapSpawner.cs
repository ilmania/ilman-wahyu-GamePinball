using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject trap;
    public float currentTrap, maxTrap, delayTime;
    private Vector3 spawnPoint;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        while (true)
        {
            if (currentTrap < maxTrap)
            {
                yield return new WaitForSecondsRealtime(delayTime);
                TrapSpawn();
            }
            yield return null;
        }
    }

    public void TrapSpawn()
    {
        float x = Random.Range(-6, 4);
        float y = Random.Range(-7, 8.5f);
        Vector3 spawnPoint = new Vector3(x, 0.5f, y);

        this.transform.position = spawnPoint;

        TrapIncrease(1);
        Instantiate(trap, spawnPoint, Quaternion.identity);
    }

    public void TrapIncrease(int number)
    {
        currentTrap = currentTrap + number;
    }

    public void TrapDecrease(int number)
    {
        currentTrap = currentTrap - number;
    }
}
