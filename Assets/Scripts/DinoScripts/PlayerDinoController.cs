using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDinoController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float rayDistance = 0.6f;
    [SerializeField] private Animator animator;
    private Rigidbody2D _rigidbody2D; 
    private RaycastHit2D _raycastHit2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        ActionManager.TouchingObstacle += OnTouchingObstacle;
    }

    
    void Update()
    {
        _raycastHit2D = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround(_raycastHit2D))
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        animator.SetBool("IsJumping", !IsOnGround(_raycastHit2D));
    }

    public void OnTouchingObstacle()
    {
        animator.SetTrigger("IsDamage");
    }
    private bool IsOnGround(RaycastHit2D raycastHit2D)
    {
        if (raycastHit2D.collider != null)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }
}
