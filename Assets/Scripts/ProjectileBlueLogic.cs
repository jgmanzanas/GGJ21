using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public float TimeToLive = 5f;
    private void Start()
    {
        Destroy(this.gameObject, TimeToLive);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "BlueEnemy")
        {
            Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }
        else if (
            collision.collider.gameObject.tag == "RedEnemy"
            ||
            collision.collider.gameObject.tag == "PurpleEnemy"
        )
        {
            Destroy(this.gameObject);
        }
    }
}
