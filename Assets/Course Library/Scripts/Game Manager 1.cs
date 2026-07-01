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
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private Button OKButton;
    private GlobalGameManager globalGameManager;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = GlobalGameManager.instance;
        Time.timeScale = 1;
        levelText.text = "Level " + globalGameManager.currentLevel;
        nextLevel.onClick.AddListener(NextLevel);
        retry.onClick.AddListener(RetryLevel);
        exit.onClick.AddListener(ExitToMenu);
        exit2.onClick.AddListener(ExitToMenu);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = globalGameManager.volume;
        Instantiate(levels[globalGameManager.currentLevel-1],Vector3.zero,transform.rotation);
        if (globalGameManager.firstTimePlaying)
        {
            tutorialUI.SetActive(true);
            globalGameManager.firstTimePlaying = false;
            Time.timeScale = 0;
            OKButton.onClick.AddListener(() => { tutorialUI.SetActive(false); Time.timeScale = 1; });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1 - Time.timeScale;
            pauseText.gameObject.SetActive(!pauseText.gameObject.activeSelf);
        }

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
        if (globalGameManager.currentLevel==levels.Count)
            nextLevel.gameObject.SetActive(false);
        Time.timeScale = 0;
        globalGameManager.levelCompleted[globalGameManager.currentLevel] = true;
        Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + " completed.");     
    }

    void RetryLevel() { 
        GotoLevel(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitToMenu() { 
        GotoLevel(0);
    }
    void NextLevel() { 
        globalGameManager.currentLevel++;
        GotoLevel(1);
    }
    public void GotoLevel(int i) {
        Time.timeScale = 1;
        SceneManager.LoadScene(i);
    }
}
