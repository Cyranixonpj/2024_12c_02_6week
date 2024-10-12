using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xInput;
    private bool _isGrounded;
   
    [SerializeField] private float JumpForce = 5;
    [SerializeField] private float Speed = 5;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
        }
        if(Input.GetButtonUp("Jump") && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
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
}
