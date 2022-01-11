using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float dashSpeed = 7f;
    [SerializeField] private float dashTime = 0.8f;
    [SerializeField] private FireballController fireball;
    [SerializeField] private float interactionRadius = 2f;
    GameObject activeFireball;
    bool canMove = true;
    bool isDashing = false;
    Vector2 movementDir = Vector2.zero;

    void FixedUpdate()
    {
        if (isDashing) return;

        Move();
    }

    void Move()
    {
        rb.velocity = movementDir * speed * Time.fixedDeltaTime;
    }

    public void Dash()
    {
        if (isDashing) return;

        rb.velocity *= dashSpeed;
        StartCoroutine(DashTimeout(dashTime));
    }

    public void Interact() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactionRadius, movementDir);

        foreach(RaycastHit2D hit in hits){
            Interactable isInteractable = hit.transform.GetComponent<Interactable>();
            if(isInteractable != null) {
                isInteractable.Interact(this);
            }
        }
    }

    public void Fireball()
    {
        if (activeFireball != null) return;

        activeFireball = Instantiate(fireball.gameObject, transform.position, Quaternion.identity);

        Vector3 dir = Vector3.zero;
        switch (anim.GetInteger("Direction"))
        {
            case 0:
                dir = Vector3.down;
                break;
            case 1:
                dir = Vector3.up;
                break;
            case 2:
                dir = Vector3.right;
                break;
            case 3:
                dir = Vector3.left;
                break;
        }

        activeFireball.transform.right = dir;
    }

    public void ChangeMovementDirection(Vector2 _dir) => movementDir = _dir;

    IEnumerator DashTimeout(float _time)
    {
        isDashing = true;
        yield return new WaitForSecondsRealtime(_time);
        isDashing = false;
    }
}
