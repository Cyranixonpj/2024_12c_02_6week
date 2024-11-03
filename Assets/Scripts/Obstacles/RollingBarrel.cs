using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBarrel : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _rb.velocity = Vector2.zero;
        }
        if(other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}