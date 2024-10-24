using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonAmmo : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Initialize(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("HasContact");
            _animator.SetTrigger("HasExploded");
            // Destroy(other.gameObject,0.2f);
            _rb.velocity = Vector2.zero;
            Destroy(gameObject,1f);
        }
        if (other.CompareTag("Ground"))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetTrigger("HasContact");
            _animator.SetTrigger("HasExploded");
            Destroy(gameObject,1f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
