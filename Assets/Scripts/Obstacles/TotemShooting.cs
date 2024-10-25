using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Obstacles
{
    public class TotemShooting : MonoBehaviour
    {
        [SerializeField] private GameObject _totemAmmoPrefab;
        [SerializeField] private float _cooldown;

        
        [Tooltip("Lista punktow z ktorych totem strzela(Musza byc dokladnie 2)Pierwszy punkt zawsze leci w lewo a drugi w przeciwnym kierunku")]
        [SerializeField] private List<Transform> _shootingPoints; 

        private void Start()
        {
            if (_shootingPoints.Count == 2)
            {
                StartCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
               
                Transform point1 = _shootingPoints[0];
                Transform point2 = _shootingPoints[1];

                
                GameObject ammoInstance1 = Instantiate(_totemAmmoPrefab, point1.position, point1.rotation);
                GameObject ammoInstance2 = Instantiate(_totemAmmoPrefab, point2.position, point2.rotation);

                TotemAmmo ammoScript1 = ammoInstance1.GetComponent<TotemAmmo>();
                TotemAmmo ammoScript2 = ammoInstance2.GetComponent<TotemAmmo>();

                if (ammoScript1 != null)
                {
                    ammoScript1.Initialize(-transform.right);
                }

                if (ammoScript2 != null)
                {
                    ammoScript2.Initialize(transform.right);
                }

                yield return new WaitForSeconds(_cooldown);
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            float trajectoryLength = 5f;

            
            Gizmos.DrawLine(_shootingPoints[0].position, _shootingPoints[0].position + (-transform.right * trajectoryLength));
            
            Gizmos.DrawLine(_shootingPoints[1].position, _shootingPoints[1].position + (transform.right * trajectoryLength));
        }
    }
}