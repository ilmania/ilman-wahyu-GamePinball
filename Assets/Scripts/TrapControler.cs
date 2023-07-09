using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControler : MonoBehaviour
{
    private Collider bola;
    private Transform pos;
    private TrapSpawner trapSpawner;
    public float SelfDestroyTime;

    private void Start()
    {
        bola = GameObject.Find("Bola").GetComponent<Collider>();
        pos = GameObject.Find("Bola").GetComponent<Transform>();
        trapSpawner = GameObject.Find("TrapSpawner").GetComponent<TrapSpawner>();
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            pos.position = new Vector3(6.73f, 1, -0.96f);
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSecondsRealtime(SelfDestroyTime);
        trapSpawner.TrapDecrease(1);
        Destroy(gameObject);
    }
}
