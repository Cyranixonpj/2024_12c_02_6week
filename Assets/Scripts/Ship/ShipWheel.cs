using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWheel : MonoBehaviour
{
    private Animator _animator;
    public bool hasPlayerTriggered = false;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayerTriggered = true;
            _animator.SetTrigger("Spin");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayerTriggered = false;
            _animator.SetTrigger("StopSpin");
        }
    }
}