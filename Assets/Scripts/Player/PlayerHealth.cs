using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;  
    [SerializeField] private int _currentHealth;
    
    private Animator _anim;
    
    
    private void Awake()
    {
        _currentHealth = _playerConfig.BaseHealth;
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
}
