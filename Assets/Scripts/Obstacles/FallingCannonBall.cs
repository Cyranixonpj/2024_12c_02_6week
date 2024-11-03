using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class FallingCannonBall : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rb;
        public Animator animator;
        private bool isGrounded = false;
        private bool hasExploded = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _rb.velocity = Vector2.down * _speed;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                
                _rb.velocity = Vector2.zero;
                Destroy(gameObject,0.3f);
                
            }
            else if (other.CompareTag("Ground"))
            {
                _rb.velocity = Vector2.zero;
                isGrounded = true;
                hasExploded = true;
                animator.SetBool("isHit", isGrounded);

                animator.SetBool("HasExploded", hasExploded);
                Destroy(gameObject, 0.2f);
            }
        }
    }
}