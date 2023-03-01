using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // variable for the speed of the player 
    public float speed = 1f;
    // variable for the jump mechanic 
    bool grounded = false;
    bool jump = false;
    Rigidbody2D myBody;
     // tunable jump variables 
    public float jumpLimit = 10f;
    public float castDist = 0.2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    // variables for 1 jump at a time 
    //bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        // access the rigidbody component on the object with the script right now 
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // player jump input 
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //// player fixed movement ////
        // player is going to the right
        // initializing position 
        Vector3 newPos = transform.position;

        // set new position
        newPos.x += speed * Time.deltaTime;

        // set the transform of the player into new position
        //transform.position = newPos;

        // if player jumps, do stuff 
        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }

        // if we are going upwards 
        if (myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;
        }
        else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        // making a raycast for calculating the player's collision with the ground 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        // drawing the raycast to make sure it's what I want it to be 
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        // if the collider hits something 
        if (hit.collider != null && hit.transform.name == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        // move the player
        myBody.velocity = new Vector3(speed, myBody.velocity.y, 0);
    }

    // when player and objects enter collision 
    void OnCollisionEnter2D(Collision2D other)
    {
        // if the game object is a spike, destroy the player 
        if (other.gameObject.name == "Spike")
        {
            Destroy(gameObject);
        }
    }
}
