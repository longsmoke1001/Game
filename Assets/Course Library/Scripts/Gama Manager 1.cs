using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamaManager1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI winningText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button retry, exit, nextLevel,exit2;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        nextLevel.onClick.AddListener(NextLevel);
        retry.onClick.AddListener(RetryLevel);
        exit.onClick.AddListener(ExitToMenu);
        exit2.onClick.AddListener(ExitToMenu);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Winning() { 
        winningText.gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + " completed.");
        GlobalGameManager.instance.levelCompleted[SceneManager.GetActiveScene().buildIndex] = true;
    }

    void RetryLevel() { 
        GotoLevel(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitToMenu() { 
        GotoLevel(0);
    }
    void NextLevel() { 
        GotoLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GotoLevel(int i) { 
        SceneManager.LoadScene(i);
        Time.timeScale= 1;
    }
}
