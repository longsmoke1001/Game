using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager instance { get; private set; }
    private GameObject goal;
    public bool[] levelCompleted { get; private set; } = new bool[100];
    [SerializeField] public float ballSpeed { get; private set; } = 0.7f;
    public int currentLevel = 1;
    public float volume = 0.2f;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SpeedChange(float f)
    {
        ballSpeed = 0.7f * 0.7f / f;
    }
    void Start()
    {

    }
    public void CompletingLevel(int level)
    {
        levelCompleted[level] = true;
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Clicked on " + gameObject.name);
    }
}
