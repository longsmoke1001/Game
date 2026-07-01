using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager0 : MonoBehaviour
{
    private bool[] levelCompleted = new bool[10];
    [SerializeField] private List<Button> levelButton;
    [SerializeField] private GameObject start;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject stageSelect;
    [SerializeField] private GameObject setting;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private GameObject howToPlayUI;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider speedSlider;
    [SerializeField] GlobalGameManager globalGameManager;
    [SerializeField] Sprite lightGreen;
    [SerializeField] Button OKButton;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(ShowStageSelect);
        settingButton.onClick.AddListener(SettingButton);
        backButton.onClick.AddListener(BackButton);
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Global Game Manager started.");
        audioSource.Play();
        levelCompleted = globalGameManager.levelCompleted;
        for (int i = 0; i < levelCompleted.Length; i++)
        {
            if (levelCompleted[i])
            {
                Debug.Log("Level " + i + " completed.");
                levelButton[i - 1].gameObject.GetComponent<Image>().sprite = lightGreen;
            }
        }
        for (int i=0;i<levelButton.Count;i++){
            int x=i;
            levelButton[i].onClick.AddListener(()=>{GotoLevel(1);GlobalGameManager.instance.currentLevel=x+1;});
        }
        OKButton.onClick.AddListener(() => { start.SetActive(!start.activeSelf); settingButton.gameObject.SetActive(!settingButton.gameObject.activeSelf); howToPlayUI.SetActive(!howToPlayUI.activeSelf); });
        howToPlayButton.onClick.AddListener(() => { start.SetActive(!start.activeSelf); settingButton.gameObject.SetActive(!settingButton.gameObject.activeSelf); howToPlayUI.SetActive(!howToPlayUI.activeSelf); });
        speedSlider.value = 0.7f * 0.7f / globalGameManager.ballSpeed;
        if (speedSlider)
            speedSlider.onValueChanged.AddListener(globalGameManager.SpeedChange);
        volumeSlider.value = globalGameManager.volume;
        if (volumeSlider)
            volumeSlider.onValueChanged.AddListener((float f) => { globalGameManager.volume = f; });
    }

    void BackButton(){
        start.SetActive(true);
        settingButton.gameObject.SetActive(true);
        stageSelect.SetActive(false);
    }
    public void ShowStageSelect()
    {
        stageSelect.SetActive(true);
        start.SetActive(false);
        settingButton.gameObject.SetActive(false);
    }

    public void SettingButton(){
        start.SetActive(!start.activeSelf);
        setting.SetActive(!setting.activeSelf);
        howToPlayButton.gameObject.SetActive(!howToPlayButton.gameObject.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GlobalGameManager.instance.volume;
    }

    public void GotoLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
