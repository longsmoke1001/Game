using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [field: SerializeField] public float jumpTime { get;private set; }
    [SerializeField] private float distY;
    [SerializeField] private float distXZ;
    [SerializeField] private GameObject gameManager;
    float jumpSpeed;
    float jumpCorrection=6;
    private int moveMultiplier = 1;
    private Vector3 velocityX;
    private Vector3 velocityZ;
    // Start is called before the first frame update
    void Start()
    {
        jumpSpeed= 2* distY / jumpTime;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.down*jumpCorrection*2*jumpSpeed/jumpTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
     void GetVelocity()
    {
            if (Input.GetKey(KeyCode.A))
            {
                velocityX = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                velocityX = Vector3.right;
            }
            else
            {
                velocityX = Vector3.zero;
            }
            if (Input.GetKey(KeyCode.W))
            {
                velocityZ = Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                velocityZ = Vector3.back;
            }
            else
            {
                velocityZ = Vector3.zero;
            }
    }
    void GetMultiplier()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveMultiplier = 2;
        }
        else
        {
            moveMultiplier = 1;
        }
    }

    void PositionAdjust()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
    }
    private void OnCollisionEnter(Collision collision)
    {
        PositionAdjust();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            GetVelocity();
            GetMultiplier();
        }
        playerRb.velocity = (velocityX + velocityZ) * distXZ / jumpTime * moveMultiplier + Vector3.up* jumpSpeed * jumpCorrection ;
        Debug.Log(transform.position);
    }
    
}
