using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 4f;
    [SerializeField] private GameObject explosionPrefab = null;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 velocity = transform.right * speed * Time.fixedDeltaTime;
        rb.velocity = velocity;
    }

    private void Die(float _lifetime = 0f) {

        explosionPrefab = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, _lifetime);

    }

    private void OnTriggerEnter2D(Collider2D _collision) {
        
        CharacterController player = _collision.gameObject.GetComponent<CharacterController>();
        if(player != null) return;

        Die();
    }
}
