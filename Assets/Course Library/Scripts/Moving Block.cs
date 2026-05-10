using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float range;
    float jumpInterval;
    Vector3 startingPosition;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition=transform.position;
        time = Time.time;
        jumpInterval=GameObject.Find("Player").GetComponent<PlayerController>().jumpTime;
        moveSpeed *= 4;
        range *= 4;
        moveSpeed /= jumpInterval;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=startingPosition+transform.forward*range*Mathf.PingPong(Time.timeSinceLevelLoad*moveSpeed/range,1);
        /*
        float progress=((Time.timeSinceLevelLoad) % (2*range/moveSpeed))/(range/moveSpeed)/2;
        
        if (progress<=0.5f)
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        */
    }
}
