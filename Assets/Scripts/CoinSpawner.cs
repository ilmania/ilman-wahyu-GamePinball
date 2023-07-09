using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin, arena;
    public float currentCoin, maxCoin, delayTime;
    private float arenaX, arenaY;
    private Vector3 spawnPoint;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        while (true)
        {
            if (currentCoin < maxCoin)
            {
                yield return new WaitForSecondsRealtime(delayTime);
                CoinSpawn();
            }
            yield return null;
        }
    }

    public void CoinSpawn()
    {
        float x = Random.Range(-6, 4);
        float y = Random.Range(-7, 8.5f);
        Vector3 spawnPoint = new Vector3(x, 1.2f, y);

        this.transform.position = spawnPoint;

        CoinIncrease(1);
        Instantiate(coin, spawnPoint, Quaternion.identity);
    }

    public void CoinIncrease(int number)
    {
        currentCoin = currentCoin + number;
    }

    public void CoinDecrease(int number)
    {
        currentCoin = currentCoin - number;
    }




}
