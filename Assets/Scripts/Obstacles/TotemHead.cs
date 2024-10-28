using System.Collections;
using System.Collections.Generic;
using Obstacles;
using UnityEngine;

public class TotemHead : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    [SerializeField] private GameObject _totemAmmo;
    [SerializeField] private float _cooldown;
    [SerializeField] private Direction _selectedDirection;
    [SerializeField] private float ammoOffsetY;
    [SerializeField] private float ammoOffsetX;
    private Animator _animator;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void Start()
    {
        if (_selectedDirection == Direction.Right)
        {
            Flip();
            ammoOffsetX *= -1;
        }

        SetAnimationSpeed();
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        while (true)
        {
            _animator.SetTrigger("Shoot");

            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length * (1 / _animator.speed));
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
    public void ShootProjectile()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + ammoOffsetX ,transform.position.y + ammoOffsetY, transform.position.z);
        GameObject ammoInstance = Instantiate(_totemAmmo, spawnPosition, transform.rotation);
        TotemAmmo ammoScript = ammoInstance.GetComponent<TotemAmmo>();
        if (ammoScript != null)
        {
            if (_selectedDirection == Direction.Left)
            {
                ammoScript.Initialize(Vector2.left);
            }
            else if (_selectedDirection == Direction.Right)
            {
                ammoScript.Initialize(Vector2.right);
            }
        }

        
    }

    private void SetAnimationSpeed()
    {
        _animator.speed = 1 / _cooldown;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float trajectoryLength = 10f;
        if (_selectedDirection == Direction.Left)
        {
            Gizmos.DrawLine(transform.position, transform.position + (-transform.right * trajectoryLength));
        }
        else
        {
            Gizmos.DrawLine(transform.position, transform.position + (transform.right * trajectoryLength));
        }
    }
}