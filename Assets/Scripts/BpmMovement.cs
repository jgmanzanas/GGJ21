using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BpmMovement : MonoBehaviour
{
    public int bpm = 100;

    private float bps;
    // Start is called before the first frame update
    void Start()
    {
        bps = bpm / 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x + bps, transform.position.y, transform.position.z
        );
    }
}
