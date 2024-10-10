using UnityEngine;
using UnityEngine.UIElements;

namespace Enemies
{
    public class EnemyPatrolling : MonoBehaviour
    {
        [SerializeField] public GameObject _enemyPrefab;
        [SerializeField] public GameObject _pointA;
        [SerializeField] public GameObject _pointB;
        [SerializeField] public int _speed;
        private Transform _currentPoint;
        private Rigidbody2D _rb;
        void Start()
        {
            _rb = _enemyPrefab.GetComponent<Rigidbody2D>();
            _currentPoint = _pointB.transform;
        }
        
        void Update()
        {
            if (_currentPoint == _pointB.transform)
            {
                _rb.velocity = new Vector2(_speed, 0);
            }
            else
            {
                _rb.velocity = new Vector2(-_speed, 0);
            }

            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform )
            {
                _currentPoint = _pointA.transform;
            }
            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform )
            {
                _currentPoint = _pointB.transform;
            }
        }
    }
}
