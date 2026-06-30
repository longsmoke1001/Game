using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI winningText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private Button retry, exit, nextLevel,exit2;
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private Image image;
    [SerializeField] private Image winningImage;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        levelText.text = "Level " + GlobalGameManager.instance.currentLevel;
        nextLevel.onClick.AddListener(NextLevel);
        retry.onClick.AddListener(RetryLevel);
        exit.onClick.AddListener(ExitToMenu);
        exit2.onClick.AddListener(ExitToMenu);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GlobalGameManager.instance.volume;
        Instantiate(levels[GlobalGameManager.instance.currentLevel-1],Vector3.zero,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Time.timeScale =1-Time.timeScale;

    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Winning() { 
        winningImage.gameObject.SetActive(true);
        winningText.gameObject.SetActive(true);
        if (GlobalGameManager.instance.currentLevel==levels.Count)
            nextLevel.gameObject.SetActive(false);
        Time.timeScale = 0;
        GlobalGameManager.instance.levelCompleted[GlobalGameManager.instance.currentLevel] = true;
        Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + " completed.");     
    }

    void RetryLevel() { 
        GotoLevel(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitToMenu() { 
        GotoLevel(0);
    }
    void NextLevel() { 
        GlobalGameManager.instance.currentLevel++;
        GotoLevel(1);
    }
    public void GotoLevel(int i) {
        Time.timeScale = 1;
        SceneManager.LoadScene(i);
    }
}
