using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gameWon;
    public GameObject gameOverPanel;
    public GameObject gameWonPanel;
    public static bool isGameStarted;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        gameWon = false;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        else if(gameWon){
            Time.timeScale = 0;
            gameWonPanel.SetActive(true);
        }
    }
}