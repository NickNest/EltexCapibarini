using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCatchingController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    private Animator animator;
    private Rigidbody2D rb;

    private Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        ActionManager.Scoring += OnScoring;
        ActionManager.Damaging += OnDamaging;
    }

    void Update()
    {
        //moveVector = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (moveVector.x != 0)
        {
            rb.velocity = moveVector;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            rb.velocity = moveVector;
            animator.SetBool("IsRunning", false);
        }

    }

    public void MoveRight()
    {
        moveVector = new Vector2(speed, rb.velocity.y);
    }
    public void StopMove()
    {
        moveVector = new Vector2(0, rb.velocity.y);
    }
    public void MoveLeft()
    {
        moveVector = new Vector2(-speed, rb.velocity.y);
    }

    public void OnScoring() => animator.SetTrigger("IsCatchWiFi");

    public void OnDamaging() => animator.SetTrigger("IsCatchBadSignal");
}
