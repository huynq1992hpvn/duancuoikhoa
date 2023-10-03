using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    public Material boxMat;
        private GameObject player;
    private PlayerController playerController;
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
        if(other.tag == "Player")
        {
            playerController.TouchedToColorBox(boxMat);
            Destroy(gameObject);
        }
    }
}
