using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText; 
    public float acceleration = 10f;    // Aceleraci�n al pulsar una tecla
    public float maxSpeed = 8f;         // Velocidad m�xima
    public int score = 0;
    Rigidbody2D rb;
    Vector2 direction;
    float angle;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.drag = 0.5f;
        rb.angularDrag = 0f;
    }

    void Update()
    {
        scoreText.text = score.ToString();
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
            angle = 0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
            angle = 180f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            angle = 90f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
            angle = 270f;
        }

        if (direction != Vector2.zero)
        {
            // Rotaci�n instant�nea
            transform.rotation = Quaternion.Euler(0, 0, angle);
            rb.AddForce(direction * acceleration);
        }

        // Limitar la velocidad m�xima
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
