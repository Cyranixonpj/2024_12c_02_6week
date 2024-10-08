using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCannonBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
    
}
