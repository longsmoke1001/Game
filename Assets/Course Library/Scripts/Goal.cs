using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private float spinPoeriod=1.5f;
    [SerializeField] private float floatingPeriod=2f;
    [SerializeField] private float floatingAmplitude=0.5f;
    // Start is called before the first frame update
    [SerializeField] private GameManager1 gameManager;
    void Start()
    {
        gameManager=FindFirstObjectByType<GameManager1>();
    }

    private void Update()
    {
        transform.Rotate(0,0, 240 * Time.deltaTime);
        transform.Translate(0,Mathf.Sin(Time.time/floatingPeriod * 2 * Mathf.PI) * floatingAmplitude * Time.deltaTime, 0, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.Winning();
        Destroy(gameObject);
    }
}

