using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolatileBlock : MonoBehaviour
{
    Material mat;
    [SerializeField] private float lives;
    [SerializeField] private float fadeTime=0.5f;
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
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade()
    {
        float t = 0;
        while (t< fadeTime)
        {
            t += Time.deltaTime;
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, Mathf.Lerp(1, 0, t / fadeTime));
            yield return null;
        }
        Destroy(gameObject);
    }
}
