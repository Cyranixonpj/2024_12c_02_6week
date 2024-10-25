using System;
using System.Collections;
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
        private Animator _animator;
        private Transform _currentPoint;
        private Rigidbody2D _rb;
        private bool _isWaiting = false;
        void Start()
        {
            _rb = _enemyPrefab.GetComponent<Rigidbody2D>();
            _animator = _enemyPrefab.GetComponent<Animator>();
            _currentPoint = _pointA.transform;
        }
        
        void Update()
        {

            if (!_isWaiting){
                _animator.SetBool("idle", false);
                if (_currentPoint == _pointB.transform)
                {
                    _rb.velocity = new Vector2(_speed, 0);
                }
                else
                {
                    _rb.velocity = new Vector2(-_speed, 0);
                }

                if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform)
                {
                    StartCoroutine(WaitAndIdle());
                    Flip();
                    _currentPoint = _pointA.transform;
                }

                if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform)
                {
                    StartCoroutine(WaitAndIdle());
                    Flip();
                    _currentPoint = _pointB.transform;
                }
            }
        }

        private void Flip()
        {
            Vector3 _localScale = transform.localScale;
            _localScale.x *= -1;
            transform.localScale = _localScale;
        }

        IEnumerator WaitAndIdle()
        {
            _isWaiting = true;
            _rb.velocity = Vector2.zero;
            _animator.SetBool("idle", true);
            yield return new WaitForSeconds(2f);
            _isWaiting = false;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(_pointB.transform.position, 0.5f);
            Gizmos.DrawLine(_pointA.transform.position,_pointB.transform.position);
        }
    }
}
