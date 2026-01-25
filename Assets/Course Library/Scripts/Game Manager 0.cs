using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager0 : MonoBehaviour
{
    private bool[] levelCompleted = new bool[10];
    [SerializeField] private Button[] levelButton;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Global Game Manager started.");
        audioSource.Play();
        levelCompleted = GlobalGameManager.instance.levelCompleted;
        for (int i = 0; i < levelCompleted.Length; i++)
        {
            if (levelCompleted[i])
            {
                Debug.Log("Level " + i + " completed.");
                levelButton[i-1].gameObject.GetComponent<Image>().color = Color.green;
            }
        }
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
