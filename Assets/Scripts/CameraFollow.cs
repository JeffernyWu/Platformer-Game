using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // variable for the speed of the player 
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // initializing position 
        Vector3 newPos = transform.position;

        // set new position
        newPos.x += speed * Time.deltaTime;

        // set the object transform into new position
        transform.position = newPos;
    }
}
