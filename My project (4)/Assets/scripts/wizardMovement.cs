using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found!");
        }
    }

    void Update()
    {
        // Get WASD input
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        if (movement.x > 0)
            transform.localScale = new Vector3(3, 3, 1);
        else if (movement.x < 0)
            transform.localScale = new Vector3(-3, 3, 1);
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}