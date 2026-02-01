using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFollow : MonoBehaviour
{

    // Lista global para que la SafeZone encuentre a todos los enemigos rápido
    public static List<EnemyFollow> AllEnemies = new List<EnemyFollow>();

    public float moveSpeed = 2f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    public bool CanFollowPlayer;

    void OnEnable() { AllEnemies.Add(this); }
    void OnDisable() { AllEnemies.Remove(this); }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = Object.FindFirstObjectByType<PlayerController>().transform;
        //GameObject.FindGameObjectWithTag
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        if (target && CanFollowPlayer)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * (moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }
    }
}
