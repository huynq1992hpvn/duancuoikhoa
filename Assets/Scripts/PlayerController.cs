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
    public Scale scaleHead;

    public GameObject headBox;
    Renderer headBoxRender;
    private Material currentHeadMat;
    public Material RedWarning;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHeadMat = headBox.transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }
    void Start()
    {
        scaleHead = new Scale();
        isPlayerMoving = true;
        headBoxRender = headBox.transform.GetChild(0).GetComponent<Renderer>();
        currentHeadMat = headBoxRender.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerMoving == false)
        {
            return;
        }
        
        float newXvalue;        
        float XLeftRight = Input.GetAxis("Horizontal");
        newXvalue = transform.position.x + XLeftRight * xSpeed * Time.deltaTime;
        newXvalue = Mathf.Clamp(newXvalue, -maxX, maxX);
        Vector3 PlayerNewPosition = new Vector3(newXvalue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = PlayerNewPosition;      


    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "FinishLine")
        {
            isPlayerMoving = false;

        }
    }
    public void PassedGate(Gatetype gatetype, int gateValue)
    {
        headBox.transform.localScale = scaleHead.CalculateHead(gatetype, gateValue, headBox.transform);
    }
    public void TouchedToColorBox(Material boxMat)
    {
        headBoxRender.material = boxMat;
        currentHeadMat = boxMat;
    }
    public void TouchedToObstacle()
    {
        headBox.transform.localScale = scaleHead.DecreasePlayerHeadS(headBox.transform);
        StartCoroutine(RedEffect());
    }
    private IEnumerator RedEffect()
    {
        headBox.transform.GetChild(0).GetComponent<MeshRenderer>().material = RedWarning;
        yield return new WaitForSeconds(0.2f);
        headBox.transform.GetChild(0).GetComponent<MeshRenderer>().material = currentHeadMat;
    }
}
