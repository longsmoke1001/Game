using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlock : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (door.GetComponent<Collider>().enabled == true) return;
        door.GetComponent<Collider>().enabled=true;
        mat.color = Color.green;
        door.GetComponent<Renderer>().material.color = Color.white;

    }
}
