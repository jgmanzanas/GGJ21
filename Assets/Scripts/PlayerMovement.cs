using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public Vector2 movement;
    private Vector2 motion;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(speed, 0);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + 0.1f * speed, transform.position.y, transform.position.z);
    }
}
