using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _anim;
    private GameObject _attackArea = default;
    private bool _attacking = false;
    private float _timeToAttack = 0.25f;
    private float _timer = 0f;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        _attackArea = transform.GetChild(0).gameObject;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _anim.SetTrigger("attackMelee");
            Attack();
            _anim.SetTrigger("attackStop");
        }
        
        if (_attacking)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToAttack)
            {
                _attacking = false;
                _timer = 0f;
                _attackArea.SetActive(_attacking);
            }
        }
    }

    private void Attack()
    {
        _attacking = true;
        _attackArea.SetActive(_attacking);
    }
}
