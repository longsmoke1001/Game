using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GamaManager1 gameManager;
    void Start()
    {
        gameManager=FindFirstObjectByType<GamaManager1>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        gameManager.Winning();
        Destroy(gameObject);
    }
}

