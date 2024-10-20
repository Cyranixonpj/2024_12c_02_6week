using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xInput;
    private bool _isGrounded;
    private bool _doubleJump;
    private bool _isFacingRight = true;
    private float _coyoteTime = 0.1f;
    private float _coyoteCounter;
    private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;
    

    [SerializeField] private float JumpForce = 5;
    [SerializeField] private float Speed = 5;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        
        if(_isGrounded)
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
                _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
                _doubleJump = !_doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            _coyoteCounter = 0f;
        }
        Flip();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * Speed, _rb.velocity.y);
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