using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperControler : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;
    public float multiplier;
    public Color color;

    private Renderer renderer;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            animator.SetTrigger("Hit");
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
        }
    }

}
