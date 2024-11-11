using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    
    [SerializeField] private Collider2D _triggerCollider2D;
    private Animator _animator;

    [SerializeField] private Doors teleportTo;
    [SerializeField] private int offTeleport;
    [SerializeField] private bool isReturnDoors = false;
    private PlayerCollectibles _playerCollectibles;
    
    private void Awake()
    {
        
        _animator = GetComponent<Animator>();
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isReturnDoors)
            {
                _animator.SetTrigger("IsOpen");
                _triggerCollider2D.enabled = false;
                StartCoroutine(WaitForAnimation(other));
            }
            else
            {
                _playerCollectibles = other.GetComponent<PlayerCollectibles>();
                if (_playerCollectibles != null && _playerCollectibles.HasKey())
                {
                    _animator.SetTrigger("IsOpen");
                    _triggerCollider2D.enabled = false;
                    _playerCollectibles.UseKey();
                    Debug.Log("Player has now: " + _playerCollectibles.GetKeyCount() + " keys");
                    StartCoroutine(WaitForAnimation(other));
                }
            }
        }
    }

    private IEnumerator WaitForAnimation(Collider2D other)
    {
        if (isReturnDoors)
        {
            yield return new WaitForSeconds(2f);
            other.transform.position = new Vector3(teleportTo.transform.position.x+offTeleport, teleportTo.transform.position.y);
        }
        else
        {
            yield return new WaitForSeconds(2f);
            other.transform.position = new Vector3(teleportTo.transform.position.x+offTeleport, teleportTo.transform.position.y);
        }
    }
   
}
