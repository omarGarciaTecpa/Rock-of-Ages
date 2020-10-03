using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    //prefab of rock
    [SerializeField]
    GameObject rockPrefab;


    //List of Rock Sprites
    [SerializeField]
    List<Sprite> sprites;

    Timer spawnTimer;

    [SerializeField]
    float spawnSeconds;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnSeconds;
        //Start timer
        spawnTimer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished) {
            //Spawner time is finished
            print("Time is up, restarting");
            spawnTimer.Run();
        }
    }
}
