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
    }

    public void TakeDamage(int damage,Vector2 hitDirecton, float k)
    {
        _currentHealth -= damage;
        _knockBack.CallKnockBack(hitDirecton,Vector2.up, k); ;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        Debug.Log("Player healed. Current health: " + _currentHealth);
    
    }

    public void Die()
    {
        _audioManager.PlaySFX(_audioManager.Death);
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
            TakeDamage(1, Vector2.up, 0.5f);
    }
}