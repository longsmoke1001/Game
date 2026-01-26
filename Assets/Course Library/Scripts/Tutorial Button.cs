using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject tutorialText;
    [SerializeField] GameObject image1;
    [SerializeField] GameObject image2;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (isActive==false)
            {
                tutorialPanel.SetActive(true);
                tutorialText.SetActive(true);
                image1.SetActive(true);
                image2.SetActive(true);
                isActive = true;
            }
            else
            {
                tutorialPanel.SetActive(false);
                tutorialText.SetActive(false);
                image1.SetActive(false);
                image2.SetActive(false);
                isActive = false;
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
