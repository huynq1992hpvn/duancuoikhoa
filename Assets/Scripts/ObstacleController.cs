using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    PlayerController playerController;
    private GameObject player;
    bool hasObstacleUsed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player" && hasObstacleUsed == false)
        {
            hasObstacleUsed = true;
            //Debug.Log("obstacle touched to Player");
            playerController.TouchedToObstacle();
        }
    }
}
