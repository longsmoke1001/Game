using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashingBlock : MonoBehaviour
{
    Material mat;
    float x;
    float time;
    [SerializeField] float flashInterval=1f;
    [SerializeField] float alteratingFactor=0;
    float jumpInterval;
    // Start is called before the first frame update
    void Start()
    {   
        time=Time.time;
        mat = GetComponent<Renderer>().material;
        jumpInterval=GameObject.Find("Player").GetComponent<PlayerController>().jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        x = 1-Mathf.PingPong((Time.timeSinceLevelLoad) * 2 / jumpInterval / flashInterval+alteratingFactor*2, 1f);
        mat.color=new Color (0,0,0,x);
        if (x < 0.5)
        {
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<Collider>().enabled = true;
        }
    }
}
