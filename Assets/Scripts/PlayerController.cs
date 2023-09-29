using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 6;
    public float xSpeed = 4;
    float maxX = 4.37f;
    bool isPlayerMoving;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerMoving == false)
        {
            return;
        }
        float touchX = 0;
        float newXvalue;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            xSpeed = 250f;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if(Input.GetMouseButton(0))
        {
            xSpeed = 500f;
            touchX = Input.GetAxis("Mouse X");
        }
        newXvalue = transform.position.x + xSpeed * touchX *Time.deltaTime;
        newXvalue = Mathf.Clamp(newXvalue, -maxX, maxX);
        Vector3 PlayerNewPosition = new Vector3(newXvalue, transform.position.y, transform.position.z + playerSpeed*Time.deltaTime);
        transform.position = PlayerNewPosition;

        
    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "FinishLine")
        {
            isPlayerMoving = false;

        }
    }

}
