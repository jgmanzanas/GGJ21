using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 1;
    BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            lives -= 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            boxCollider.enabled = false;
        }
    }
}
