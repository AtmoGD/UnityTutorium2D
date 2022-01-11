using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.x < 0)
            animator.SetInteger("Direction", 3);
        if (rb.velocity.x > 0)
            animator.SetInteger("Direction", 2);
        if (rb.velocity.y > 0)
            animator.SetInteger("Direction", 1);
        if (rb.velocity.y < 0)
            animator.SetInteger("Direction", 0);

        animator.SetBool("IsMoving", rb.velocity.magnitude > 0);
    }
}
