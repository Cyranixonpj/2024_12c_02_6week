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
    [SerializeField]private float ammoOffsetY = -0.5f;
    

    private void Start()
    {
        if (_selectedDirection == Direction.Right)
        {
            Flip();
        }
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        while (true)
        {
            
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + ammoOffsetY, transform.position.z);
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

            yield return new WaitForSeconds(_cooldown);
        }
    }

    private void Flip()
    {
        // Zapisz aktualną pozycję obiektu
        Vector3 savedPosition = transform.position;

        // Zmień skalę obiektu (flip)
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        // Przywróć pozycję obiektu
        transform.position = savedPosition;
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