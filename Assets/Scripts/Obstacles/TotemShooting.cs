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
        private void Start()
        {
            StartCoroutine(Shoot());
        } 
        private IEnumerator Shoot()
        {
            while (true)
            {
                Instantiate(_totemAmmoPrefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(_cooldown);
                
            }
        }
    
    }
}

