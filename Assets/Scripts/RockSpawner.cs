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

    //Seconds before the next spawn
    [SerializeField]
    float spawnSeconds = 0f;

    //Rocks to be created
    [SerializeField]
    int rockAmount = 0;

    //Keep Track of rocks in the scene
    private int rocksInScene = 0;


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
        rocksInScene = GameObject.FindGameObjectsWithTag("GameRock").Length;

        if (spawnTimer.Finished &&  rocksInScene < rockAmount) {
            //Spawner time is finished
            
            SpawnRock();     
            spawnTimer.Run();
        }
    }


    void SpawnRock() {

        //Spawn a new Rock
        GameObject rock = Instantiate(rockPrefab) as GameObject;

        //Get prefab renderer
        SpriteRenderer renderer = rock.GetComponent<SpriteRenderer>();

        //Random 
        if (sprites.Count > 0) {
            int spriteIndex = UnityEngine.Random.Range(0, sprites.Count);
            renderer.sprite = sprites[spriteIndex];
        }


    }
}
