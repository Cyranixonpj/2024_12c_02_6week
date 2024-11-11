using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    
    [SerializeField] private Collider2D _triggerCollider2D;
    [SerializeField] private Doors teleportTo;
    [SerializeField] private int offTeleport;
    [SerializeField] private bool isReturnDoors = false;
    private Animator _animator;
    private bool isOpened = false;
    
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
                StartCoroutine(WaitForAnimation(other));
            }
            else
            {
                if (isOpened)
                {
                    StartCoroutine(WaitForAnimation(other));
                }
                else
                {
                    _playerCollectibles = other.GetComponent<PlayerCollectibles>();
                    if (_playerCollectibles != null && _playerCollectibles.HasKey())
                    {
                        _animator.SetTrigger("IsOpen");
                        _playerCollectibles.UseKey();
                        Debug.Log("Player has now: " + _playerCollectibles.GetKeyCount() + " keys");
                        StartCoroutine(WaitForAnimation(other));
                    }
                }
                
            }
        }
    }

    private IEnumerator WaitForAnimation(Collider2D other)
    {
        if (isReturnDoors)
        {
            yield return new WaitForSeconds(1f);
            other.transform.position = new Vector3(teleportTo.transform.position.x+offTeleport, teleportTo.transform.position.y-1);
        }
        else
        {
            if (isOpened)
            {
                yield return new WaitForSeconds(1f);
                other.transform.position = new Vector3(teleportTo.transform.position.x+offTeleport, teleportTo.transform.position.y-1);
            }
            else
            {
                teleportTo.isOpened = true;
                teleportTo._animator.Play("Doors_Open");
                isOpened = true;
                yield return new WaitForSeconds(1f);
                other.transform.position = new Vector3(teleportTo.transform.position.x+offTeleport, teleportTo.transform.position.y-1);    
            }
            
        }
    }
   
}
