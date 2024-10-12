using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xInput;
    
    [SerializeField] private float Speed = 5;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
    }
    
    
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * Speed, _rb.velocity.y);
    }
}
