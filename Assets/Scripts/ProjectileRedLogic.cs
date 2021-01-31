using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRedLogic : MonoBehaviour
{
    public float TimeToLive = 5f;
    private EnemiesLogic enemiesScript;
    private void Start()
    {
        Destroy(this.gameObject, TimeToLive);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "RedEnemy")
        {
            enemiesScript = collision.collider.gameObject.GetComponent<EnemiesLogic>();
            enemiesScript.lives -= 1;
            // Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }
        else if (
            collision.collider.gameObject.tag == "BlueEnemy"
            ||
            collision.collider.gameObject.tag == "PurpleEnemy"
        )
        {
            Destroy(this.gameObject);
        }
    }
}
