using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonAmmo : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        // Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
