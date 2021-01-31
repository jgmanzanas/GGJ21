using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 1;
    public float TimeToLive = 5f;

    public int score = 10;

    BoxCollider2D boxCollider;

    private GameObject player;
    private PlayerLogic playerScript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerLogic>();
        boxCollider = GetComponent<BoxCollider2D>();
        Destroy(this.gameObject, TimeToLive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            Destroy(boxCollider);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            Destroy(this.gameObject);
            playerScript.addScore(score);
        }
    }
}
