using UnityEngine;

namespace Obstacles
{
    public class TotemAmmo : MonoBehaviour
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
                Destroy(gameObject, 1f);
            }
            if (other.CompareTag("Ground") || other.CompareTag("Barrel"))
            {
                Destroy(gameObject,1f);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}

