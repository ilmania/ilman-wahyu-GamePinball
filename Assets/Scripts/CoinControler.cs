using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControler : MonoBehaviour
{

    private Collider bola;
    private CoinSpawner coinSpawner;
    public float SelfDestroyTime;

    private void Start()
    {
        bola = GameObject.Find("Bola").GetComponent<Collider>();
        coinSpawner = GameObject.Find("CoinSpawner").GetComponent<CoinSpawner>();
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            coinSpawner.CoinDecrease(1);
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSecondsRealtime(SelfDestroyTime);
        coinSpawner.CoinDecrease(1);
        Destroy(gameObject);
    }

}
