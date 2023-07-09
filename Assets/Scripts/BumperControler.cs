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
    private int colorInt;

    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
        colorInt = 1;
        ChangeColor();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            ChangeColor();
            animator.SetTrigger("Hit");
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
        }
    }

    private void ChangeColor()
    {
        switch (colorInt)
        {
            case (1):
                renderer.material.color = Color.green;
                colorInt = 2;
                break;
            case (2):
                renderer.material.color = Color.yellow;
                colorInt = 3;
                break;
            case (3):
                renderer.material.color = Color.red;
                colorInt = 1;
                break;
            default:
                break;
        }
    }

}
