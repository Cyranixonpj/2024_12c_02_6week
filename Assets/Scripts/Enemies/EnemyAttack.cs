using Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator _animator;
    private EnemyPatrolling _enemyPatrolling;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _enemyPatrolling = gameObject.GetComponent<EnemyPatrolling>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitAndAttack());
        }
    }
    
    IEnumerator WaitAndAttack()
    {
        _enemyPatrolling._isWaiting = true;
        _animator.SetTrigger("attack");
        yield return new WaitForSeconds(1f);
        _enemyPatrolling._isWaiting = false;
    }
}