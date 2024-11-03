using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    [SerializeField] private GameObject _canonAmmo;
    [SerializeField] private GameObject _smoke;
    [SerializeField] private float _cooldown;
    [SerializeField] private Direction _selectedDirection;
    private float ammoOffsetX = -0.1f;
    private float smokeOffsetX = -0.8f;
    private Animator _animator;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
        SetAnimationSpeed();
        if (_selectedDirection == Direction.Right)
        {
            Flip();
            ammoOffsetX = 0.5f;
            smokeOffsetX = 0.8f;
        }
        
        StartCoroutine(Shoot());
        
    }
    
    private void SetAnimationSpeed()
    {
        _animator.speed = 1 / _cooldown;
    }

   
    
    public void FireAmmo()
    {
        
        Vector3 ammoSpawn = new Vector3(transform.position.x + ammoOffsetX, transform.position.y + 0.1f , transform.position.z);
        Vector3 smokeSpawn = new Vector3(transform.position.x + smokeOffsetX, transform.position.y +0.1f , transform.position.z);
        
        GameObject ammoInstance = Instantiate(_canonAmmo, ammoSpawn, transform.rotation);
        CanonAmmo ammoScript = ammoInstance.GetComponent<CanonAmmo>();
        
        GameObject smokeInstance = Instantiate(_smoke, smokeSpawn, transform.rotation);
        
        if (ammoScript != null)
        {
            if (_selectedDirection == Direction.Left)
            {
                ammoScript.Initialize(Vector2.left);
                
                
            }
            else if (_selectedDirection == Direction.Right)
            {
                Vector3 smokeScale = smokeInstance.transform.localScale;
                smokeScale.x *= -1;
                smokeInstance.transform.localScale = smokeScale;
                
                ammoScript.Initialize(Vector2.right);
            }
        }
    }
    
    private IEnumerator Shoot()
    {
        while (true)
        {
            
            _animator.SetTrigger("Fire");
            
            yield return new WaitForSeconds(1/_cooldown);
            
        }
    }
    private void Flip()
    {
        
        Vector3 savedPosition = transform.position;

        
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        
        transform.position = savedPosition;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float trajectoryLength = 10f;
        if (_selectedDirection==Direction.Left)
        {
            Gizmos.DrawLine(transform.position, transform.position + (-transform.right * trajectoryLength));
        }
        else
        {
            Gizmos.DrawLine(transform.position, transform.position + (transform.right * trajectoryLength));
        }

    } 
}
