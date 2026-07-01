using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [field: SerializeField] public float jumpTime { get; private set; }
    [SerializeField] private float distY;
    [SerializeField] private float distXZ;
    private GameManager1 gameManager;
    float jumpSpeed;
    float jumpCorrection = 6;
    private int moveMultiplier = 1;
    private Vector3 velocityX;
    private Vector3 velocityZ;
    private float XRotation;
    private float ZRotation;
    // Start is called before the first frame update
    void Start()
    {
        jumpTime = GlobalGameManager.instance.ballSpeed;
        jumpSpeed = 2 * distY / jumpTime;
        playerRb = GetComponent<Rigidbody>();
        gameManager = FindAnyObjectByType<GameManager1>();
        Physics.gravity = Vector3.down * jumpCorrection * 2 * jumpSpeed / jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            gameManager.GameOver();
        }
    }
    void GetVelocity()
    {
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            velocityX = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            velocityX = Vector3.right;
        }
        else
        {
            velocityX = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            velocityZ = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
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
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            GetVelocity();
            GetMultiplier();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        playerRb.angularVelocity = new Vector3(velocityZ.z*180*Mathf.Deg2Rad, 0, -velocityX.x * 180 * Mathf.Deg2Rad);
        playerRb.velocity = (velocityX + velocityZ) * distXZ / jumpTime * moveMultiplier + Vector3.up * jumpSpeed * jumpCorrection;
        Debug.Log(transform.position);
    }

}
