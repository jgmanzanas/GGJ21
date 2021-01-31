using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLogic : MonoBehaviour
{
    public float speed = 2;
    private bool running = false;
    private Vector3 startingPosition;
    public float endGame = 100;
    public GameObject pedestal;
    private GameObject player;
public Image Ganar;
public Text Win;

    void Start()
    {
        player = GameObject.Find("Player");
        startingPosition = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z
        );
    }


    private void Update()
    {
        GameObject pedestalInstanciated = GameObject.Find("Pedestal(Clone)");
        if (!running)
        {
            StartCoroutine(waitThreeSeconds());
            return;
        }
        if (pedestalInstanciated)
        {
            Win.enabled = true;
Ganar.enabled = true;
StartCoroutine(waitThreeSeconds());
            return;
        }
        else if (transform.position.x >= startingPosition.x + endGame)
        {
            speed = 0;
            Instantiate(
                pedestal, new Vector3(
                    player.transform.position.x + 4,
                    player.transform.position.y,
                    player.transform.position.z
                ), transform.rotation, player.transform
            );
            Application.Quit();
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x + 0.1f * speed, transform.position.y, transform.position.z
            );
        }
    }
    IEnumerator waitThreeSeconds() {
        yield return new WaitForSeconds(3);
        running = true;
    }
}
