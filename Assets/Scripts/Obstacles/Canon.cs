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
    [SerializeField] private float _cooldown;
    [SerializeField] private Direction _selectedDirection;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject ammoInstance = Instantiate(_canonAmmo, transform.position, transform.rotation);
            CanonAmmo ammoScript = ammoInstance.GetComponent<CanonAmmo>();
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

            yield return new WaitForSeconds(_cooldown);
        }
    }private void OnDrawGizmos()
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