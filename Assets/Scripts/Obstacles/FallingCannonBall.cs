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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                hasExploded = true;
                animator.SetBool("isHit", isGrounded);

                animator.SetBool("HasExploded", hasExploded);
                Destroy(gameObject, 0.5f);
            }
        }
    }
}