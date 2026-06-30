using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward*499;
    }
}
