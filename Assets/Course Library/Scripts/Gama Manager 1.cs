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
    [SerializeField] private Button retry, exit, nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        nextLevel.onClick.AddListener(NextLevel);
        retry.onClick.AddListener(RetryLevel);
        exit.onClick.AddListener(ExitToMenu);
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
        GlobalGameManager.instance.levelCompleted[SceneManager.GetActiveScene().buildIndex]=true;
        Time.timeScale = 0;
        Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + " completed.");

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
        Time.timeScale = 1;
    }
}
