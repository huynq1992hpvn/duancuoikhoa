using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Gatetype
{
    fatterType,
    thinnerType,
    tallerType,
    shorterType
}
public class GateController : MonoBehaviour
{
    public int gateValue;
    public RawImage gateImage;
    public TMPro.TextMeshProUGUI gateText;
    public Texture[] textures;
    public Gatetype gatetype;
    public GameObject player;
    public PlayerController playerController;
    bool hasGateUsed;
    private GateHolderController holderController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        holderController = transform.parent.gameObject.GetComponent<GateHolderController>();
        AddGateValueAndSymbol();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddGateValueAndSymbol()
    {
        gateText.text = gateValue.ToString();
        switch (gatetype)
        {
            case Gatetype.fatterType:
                gateImage.texture = textures[0];
                break;
            case Gatetype.thinnerType:
                gateImage.texture = textures[1];
                break;
            case Gatetype.tallerType:
                gateImage.texture = textures[2];
                break;
            case Gatetype.shorterType:
                gateImage.texture = textures[3];
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasGateUsed == false)
        {
            hasGateUsed = true;
            playerController.PassedGate(gatetype, gateValue);
            if(holderController != null)
            {
                holderController.CloseGates();
            }
            
            Destroy(gameObject);
        }
    }
}
