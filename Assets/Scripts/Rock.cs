using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    //Create rock and add force and direction to it.
    void Start()
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;

        //Position object relative to camera view
        CenterToCamera();

        //Create a random angle 
        float angle = Random.Range(0, 2 * Mathf.PI);

        //Create a direction
        Vector2 direction = new Vector2( Mathf.Cos(angle), Mathf.Sin(angle));
        
        //Create a magnitude based on the min and max impuse
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        
        //add Force based on the direction and magnitude
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }


    void CenterToCamera() {
        Vector3 location = new Vector3(Screen.width / 2, Screen.height / 2, -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        transform.position = worldLocation;
    }

    // Destroy the rock if out of sight
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
