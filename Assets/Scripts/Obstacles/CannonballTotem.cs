using UnityEngine;

namespace Obstacles
{
    public class Cannonball : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rb; 
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _rb.velocity = transform.right * _speed;
        } 
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        
        }
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}

