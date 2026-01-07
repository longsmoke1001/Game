using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float range;
    float jumpInterval;
    // Start is called before the first frame update
    void Start()
    {
        jumpInterval=GameObject.Find("Player").GetComponent<PlayerController>().jumpTime;
        moveSpeed *= 4;
        range *= 4;
        moveSpeed /= jumpInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % (2*range/moveSpeed) >= range/moveSpeed)
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
