using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Basic demonstration of a music system that uses PlayScheduled to preload and sample-accurately
// stitch two AudioClips in an alternating fashion.  The code assumes that the music pieces are
// each 16 bars (4 beats / bar) at a tempo of 140 beats per minute.
// To make it stitch arbitrary clips just replace the line
//   nextEventTime += (60.0 / bpm) * numBeatsPerSegment
// by
//   nextEventTime += clips[flip].length;
[RequireComponent(typeof(AudioSource))]
public class SyncSongLogic : MonoBehaviour
{
    public float bpm = 100.0f;
    public int numBeatsPerSegment = 16;
    public AudioClip[] clips = new AudioClip[2];
    public GameObject child;
    public float cameraSpeed;
    public string difficulty = "Normal";
    public BoxCollider2D enemyRed;
    public BoxCollider2D enemyBlue;
    public BoxCollider2D enemyPurple;

    private Camera cam;
    private double nextEventTime;
    private int flip = 0;
    private Vector3 cameraOffset;

    private AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;
    private float startpos;
    private int maxRange = 3;

    private void createEnemiesNormal(int selection, Vector3 enemyWorldPosition)
    {
        if (selection == 0)
        {
            Instantiate(
                enemyRed, enemyWorldPosition, transform.rotation
            );
        }
        else if (selection == 1)
        {
            Instantiate(
                enemyBlue, enemyWorldPosition, transform.rotation
            );
        }
        else if (selection == 2)
        {
            Instantiate(
                enemyPurple, enemyWorldPosition, transform.rotation
            );
        }
    }

    private void createEnemiesHard(int selection, Vector3 enemyWorldPosition)
    {
        Vector3 enemyPosition2 = new Vector3(
            Screen.width + cameraSpeed + 100,
            Screen.height / 2 + 8,
            10
        );
        Vector3 enemyWorldPosition2 = cam.ScreenToWorldPoint(enemyPosition2);

        if (selection == 3)
        {
            Instantiate(
                enemyRed, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyBlue, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 4)
        {
            Instantiate(
                enemyBlue, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyRed, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 5)
        {
            Instantiate(
                enemyPurple, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyRed, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 6)
        {
            Instantiate(
                enemyRed, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyPurple, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 7)
        {
            Instantiate(
                enemyPurple, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyBlue, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 8)
        {
            Instantiate(
                enemyRed, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyRed, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 9)
        {
            Instantiate(
                enemyBlue, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyPurple, enemyWorldPosition2, transform.rotation
            );
        }
        else if (selection == 10)
        {
            Instantiate(
                enemyBlue, enemyWorldPosition, transform.rotation
            );
            Instantiate(
                enemyBlue, enemyWorldPosition2, transform.rotation
            );
        }
    }

    private void createEnemies(int selection)
    {
        Vector3 enemyPosition = new Vector3(
            Screen.width + cameraSpeed,
            Screen.height / 2 + 8,
            10
        );
        Vector3 enemyWorldPosition = cam.ScreenToWorldPoint(enemyPosition);

        if (selection <= 3)
        {
            createEnemiesNormal(selection, enemyWorldPosition);
        }
        else
        {
            createEnemiesHard(selection, enemyWorldPosition);
        }
    }

    void Start()
    {
        if (difficulty == "Hard")
        {
            maxRange = 11;
        }
        else
        {
            difficulty = "Normal";
            maxRange = 3;
        }
        for (int i = 0; i < 2; i++)
        {
            // GameObject child = new GameObject("Player");
            cam = Camera.main;
            startpos = gameObject.transform.position.x;
            Vector3 cameraOffset = new Vector3(cameraSpeed, 0, 0);
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>();
        }

        nextEventTime = AudioSettings.dspTime + 2.0f;
        Debug.Log("Scheduled start at time " + nextEventTime);
        running = true;
    }

    void Update()
    {
        if (!running)
        {
            return;
        }

        double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            // We are now approx. 1 second before the time at which the sound should play,
            // so we will schedule it now in order for the system to have enough time
            // to prepare the playback at the specified time. This may involve opening
            // buffering a streamed file and should therefore take any worst-case delay into account.
            audioSources[flip].clip = clips[flip];
            audioSources[flip].PlayScheduled(nextEventTime);

            // Place the next event 16 beats from here at a rate of 140 beats per minute
            nextEventTime += (60.0f / bpm) * numBeatsPerSegment;
            int enemyType = Random.Range(0, maxRange);
            Debug.Log("Enemy Type " + enemyType);
            createEnemies(enemyType);

            Debug.Log("Scheduled source " + flip + " to start at time " + nextEventTime);

            // Flip between two audio sources so that the loading process of one does not interfere with the one that's playing out
            flip = 1 - flip;
        }
    }
}
