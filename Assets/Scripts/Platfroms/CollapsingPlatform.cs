using System;
using System.Collections;
using UnityEngine;

namespace Platfroms
{
    public class CollapsingPlatform : MonoBehaviour
    {
        [SerializeField] private float closeAgainCooldown;
        [SerializeField] private float openDelay;
        [SerializeField] private BoxCollider2D bxCol;
        
        [SerializeField] private Animator _part1Animator;
        [SerializeField]private Animator _part2Animator;
        // [SerializeField]private Collider2D _part1Collider;
        // [SerializeField]private Collider2D _part2Collider;
        
        
        
        // private Animator _animator;
        private bool _isOpening = false;
        private bool _playerOnPlatform = false;

        private void Awake()
        {
            
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player") && !_isOpening)
            {
                _playerOnPlatform = true;
                _isOpening = true;
                StartCoroutine(Opening());
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.transform.CompareTag("Player"))
            {
                _playerOnPlatform = false;
            }
        }

        private IEnumerator Opening()
        {
           //  float animationTime = closeAgainCooldown;
           //  float part1Speed = _part1Animator.speed;
           //  float part2Speed = _part2Animator.speed;
           // _part1Animator.SetTrigger("Open");
           // _part2Animator.SetTrigger("Open");
           //
           // _part1Animator.speed = 1f/animationTime;
           // _part2Animator.speed = 1f/animationTime;
           //
           //
           // if (_playerOnPlatform)
           // {
           //     yield return new WaitForSeconds(openDelay);
           //     _part1Collider.enabled = false;
           //     _part2Collider.enabled = false;
           //     
           //     // _collider2D.enabled = false;
           //
           //     yield return new WaitForSeconds(closeAgainCooldown);
           //     
           //     // _collider2D.enabled = true;
           //
           //     _part1Collider.enabled = true;
           //     _part2Collider.enabled = true;
           // }
           //  _part1Animator.speed = part1Speed;
           //  _part2Animator.speed = part2Speed;
           //
           // _isOpening = false;
           
           
           
           float animationTime = closeAgainCooldown;
           float part1Speed = _part1Animator.speed;
           float part2Speed = _part2Animator.speed;
           
           _part1Animator.speed = part1Speed;
           _part2Animator.speed = part2Speed;
           
           _part1Animator.speed = 1f/animationTime;
           _part2Animator.speed = 1f/animationTime;
           if (_playerOnPlatform)
           {
               yield return new WaitForSeconds(openDelay);
               _part1Animator.SetTrigger("Open");
               _part2Animator.SetTrigger("Open");
               bxCol.enabled = false;
               yield return new WaitForSeconds(closeAgainCooldown);
               bxCol.enabled = true;
               
               
           }
           _isOpening = false;
               
              
           
                
            
        }
    }
}
