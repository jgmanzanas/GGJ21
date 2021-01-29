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

    // Update is called once per frame
    /* void Update()
    {
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(motion * speed * Time.deltaTime);
    }
    */
    void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
