using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager instance { get; private set; }
    private GameObject goal;
    public bool[] levelCompleted { get; private set; } = new bool[10];
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

    void Start()
    {

    }
    void CompletingLevel(int level)
    {
        levelCompleted[level]=true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Clicked on " + gameObject.name);
    }
}
