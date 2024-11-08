using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    
    [SerializeField] private Collider2D _triggerCollider2D;
    private Animator _animator;
    

    private PlayerCollectibles _playerCollectibles;
    
   
    private void Awake()
    {
        
        _animator = GetComponent<Animator>();
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerCollectibles = other.GetComponent<PlayerCollectibles>();
            if (_playerCollectibles != null && _playerCollectibles.HasKey())
            {
                
                _animator.SetTrigger("IsOpen");
                _triggerCollider2D.enabled = false;
                _playerCollectibles.UseKey();
                Debug.Log("Player has now: " + _playerCollectibles.GetKeyCount() + " keys");
            }
        }
    }
   
}
