using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAreaControler : MonoBehaviour
{
    public GameObject bola;
    private Collider col;
    private Transform pos;

    void Start()
    {
        col = bola.GetComponent<Collider>();
        pos = bola.GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == col)
        {
            pos.position = new Vector3(6.73f, 1, -0.96f);
        }
    }
}
