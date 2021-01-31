using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBlueLogic : MonoBehaviour
{
    public float TimeToLive = 5f;
    private EnemiesLogic enemiesScript;
    private void Start()
    {
        Destroy(this.gameObject, TimeToLive);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "BlueEnemy")
        {
            enemiesScript = collision.collider.gameObject.GetComponent<EnemiesLogic>();
            enemiesScript.lives -= 1;
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
