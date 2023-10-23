using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private int currentLevel = 1;
    private int maxLevel;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        maxLevel = 3;
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            SceneManager.LoadScene("Endgame");
        }

        else
        {
            string nextLevelName = "Level" + currentLevel;

            SceneManager.LoadScene(nextLevelName);
        }
    }
}
