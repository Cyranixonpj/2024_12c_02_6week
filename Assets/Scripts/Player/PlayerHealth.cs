using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    public int _currentHealth { get; private set; }
    public int _maxHealth { get; private set; }

    private Animator _anim;


    private void Awake()
    {
        _currentHealth = _playerConfig.BaseHealth;
        _maxHealth = _playerConfig.MaxHealth;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _anim.SetTrigger("dead");
        OnDeathAnimationEnd();
    }

    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject, 0.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}