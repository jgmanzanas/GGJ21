using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public float speed = 2;
    // private int bpm = 100;
    private Vector2 movement;
    private bool running = false;
    GameObject floor;

    void Start()
    {
    }


    private void FixedUpdate()
    {
        if (!running)
        {
            StartCoroutine(waitThreeSeconds());
            return;
        }
        transform.position = new Vector3(
            transform.position.x + 0.1f * speed, transform.position.y, transform.position.z
        );
    }
    IEnumerator waitThreeSeconds() {
        yield return new WaitForSeconds(3);
        running = true;
    }
}
