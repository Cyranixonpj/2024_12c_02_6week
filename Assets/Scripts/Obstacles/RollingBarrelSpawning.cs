using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBarrelSpawning : MonoBehaviour
{
    [SerializeField] private GameObject _rollingBarrelPrefab;
    [SerializeField] private float _cooldown;
    private void Start()
    {
        StartCoroutine(Falling());
        
    }
    private IEnumerator Falling()
    {
        while (true)
        {
            Instantiate(_rollingBarrelPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(_cooldown);
            
        }
    }
}
