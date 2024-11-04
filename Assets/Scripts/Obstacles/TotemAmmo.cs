using UnityEngine;

namespace Obstacles
{
    public class TotemAmmo : MonoBehaviour
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
                _rb.velocity = Vector2.zero;
                _animator.SetTrigger("IsHit");
                Destroy(gameObject, 1f);
            }
            if (other.CompareTag("Ground") || other.CompareTag("Barrel")||other.CompareTag("Wall"))
            {
                
                _rb.velocity = Vector2.zero;
                _animator.SetTrigger("IsHit");
                Destroy(gameObject,1f);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}

