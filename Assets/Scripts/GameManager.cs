using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject StartMenuPanel;
    public GameObject player;
    public GameObject VictoryPanel;
    public GameObject FailedMenuPanel;
    public PlayerController PlayerController;
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartButtonTapped()
    {
        StartMenuPanel.gameObject.SetActive(false);

        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.GameStarted();
    }
    public void NextLevelButton()
    {
        VictoryPanel.gameObject.SetActive(false);
        LevelController.Instance.NextLevel();

    }
    public void ShowSucessMenu()
    {
        VictoryPanel.gameObject.SetActive(true);
    }
    public void RestartButtonTapped()
    {
        SceneManager.LoadScene("Level1");

    }
    public void ShowFailedMenuPannel()
    {
        FailedMenuPanel.SetActive(true);
        

    }
}
