using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private float _xInput;
    private bool _isGrounded;
    private bool _doubleJump;
    private bool _isFacingRight = true;
    private float _coyoteTime = 0.1f;
    private float _coyoteCounter;
    public bool levelEnd;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    [SerializeField] private float JumpForce = 5;
    [SerializeField] private float Speed = 5;

    private KnockBack _knockBack;
    

    private void Awake()
    {
        //Grab references
        levelEnd = false;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _knockBack = GetComponent<KnockBack>();
        
    }

    private void Update()
    {
        if (!_knockBack.isBeingKnockedBack  )
        {
            _xInput = Input.GetAxis("Horizontal");

            Jump();
            Flip();

            _anim.SetBool("run", _xInput != 0);
            _anim.SetBool("fall", _rb.velocity.y < 0 && _coyoteCounter > 0f);
            _anim.SetBool("touchedGround", _coyoteCounter > 0f);
        }
        else
        {
            _xInput = 0;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded() )
        {
            _rb.velocity = new Vector2(_xInput * Speed, _rb.velocity.y);
        }
     
    }

    private void Jump()
    {
        if (isGrounded())
        {
            _coyoteCounter = _coyoteTime;
        }
        else
        {
            _coyoteCounter -= Time.deltaTime;
        }


        if (_coyoteCounter > 0f && !Input.GetButton("Jump"))
        {
            _doubleJump = false;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (_coyoteCounter > 0f || _doubleJump)
            {
                _anim.SetTrigger("jump");
                _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
                _doubleJump = !_doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            _coyoteCounter = 0f;
        }

        _anim.SetBool("grounded", _coyoteCounter > 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HealPotion"))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.Heal(5);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("InstantDeath"))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.TakeDamage(10);
        }

        if (other.gameObject.CompareTag("LevelEnd"))
        {
            levelEnd = true;
        }
    }
    

    private void OnCollisionExit2D(Collision2D other)
    {
        // if (other.gameObject.CompareTag("Ground"))
        // {
        //     _isGrounded = false;
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.gameObject.CompareTag("Ground"))
        // {
        //     Vector3 normal = other.GetContact(0).normal;
        //     if (normal == Vector3.up)
        //     {
        //         _isGrounded = true;
        //     }
        //     
        // }

        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            Vector2 hitDirection = (transform.position - other.transform.position).normalized;
            playerHealth.TakeDamageKB(1, hitDirection, Input.GetAxisRaw("Horizontal"));
        }


        if (other.gameObject.CompareTag("Barrel"))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.TakeDamage(5);
        }
    }
    
    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up*castDistance,boxSize);
        
    }


    private void Flip()
    {
        if (_isFacingRight && _xInput < 0 || !_isFacingRight && _xInput > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}