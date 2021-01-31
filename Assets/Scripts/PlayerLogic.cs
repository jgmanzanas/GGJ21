using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 3;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    public Rigidbody2D noteRed;
    public Rigidbody2D noteBlue;
    public float speed = 2;
    public string[] enemyTags = {"RedEnemy", "BlueEnemy", "PurpleEnemy"};

    private Vector3 projectileOffset = new Vector3(3, 0, 0);
    private Quaternion rotation;
    private bool running = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rotation = transform.rotation;
    }

    IEnumerator waitThreeSeconds() {
        yield return new WaitForSeconds(3);
        running = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        else if(enemyTags.Contains(collision.gameObject.tag))
        {
            lives -= 1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }

    private void Update()
    {
        if (!running)
        {
            StartCoroutine(waitThreeSeconds());
            return;
        }
        if(lives < 1)
        {
            // Debug.Log("No lives");
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Rigidbody2D nt = Instantiate(noteRed, transform.position + projectileOffset, transform.rotation);
            // Multiply by 2 times the speed on the camera
            nt.velocity = new Vector2(4 * speed, 0.0f);
        }

        else if(Input.GetKeyDown(KeyCode.K))
        {
            Rigidbody2D nt = Instantiate(noteBlue, transform.position + projectileOffset, transform.rotation);
            // Multiply by 2 times the speed on the camera
            nt.velocity = new Vector2(4 * speed, 0.0f);
        }

    }
}
