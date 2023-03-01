using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    public GameObject Player_follow;
    public GameObject Player;
    public GameObject YouWin_UI; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if you reach the end, load victory screen
        if (other.gameObject.name == "Player")
        {
            YouWin_UI.SetActive(true);
            Destroy(Player);
            Destroy(Player_follow);
        }
    }
}
