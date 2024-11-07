using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    public int _currentHealth { get; private set; }
    public int _maxHealth { get; private set; }

    private Animator _anim;
    private AudioManager _audioManager;
    private KnockBack _knockBack;
    private PlayerMovement _playerMovement;
  


    private void Awake()
    {
       
        _currentHealth = _playerConfig.BaseHealth;
        _maxHealth = _playerConfig.MaxHealth;
        _anim = GetComponent<Animator>();
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _knockBack = GetComponent<KnockBack>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void TakeDamageKB(int damage, Vector2 hitDirecton, float k)
    {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            _knockBack.CallKnockBack(hitDirecton, Vector2.up, k);
            _anim.SetTrigger("hit");
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            _anim.SetTrigger("hit");
        }
    }

    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void Die()
    {
        _playerMovement.enabled = false;
        _audioManager.PlaySFX(_audioManager.Death);
        _anim.SetTrigger("dead");
    }




    
}