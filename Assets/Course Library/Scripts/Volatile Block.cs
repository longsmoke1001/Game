using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolatileBlock : MonoBehaviour
{
    Material mat;
    [SerializeField] private float lives; 
    // Start is called before the first frame update
    void Start()
    {
        mat= GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        lives-=0.5f;
        if (lives == 2)
        {
            mat.color = Color.red+Color.green/2;
        }
        else if (lives == 1)
        {
            mat.color = Color.red;
        }
        else if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
