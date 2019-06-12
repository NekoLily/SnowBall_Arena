using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    int limitemax = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            if (limitemax <= 200)
            {
                Debug.Log("devient gros");
                transform.localScale += new Vector3(0.12F, 0.12F, 0);
                limitemax += 1;
            }
            if (limitemax <= 400)
            {
                Debug.Log("devient gros");
                transform.localScale += new Vector3(0.10F, 0.10F, 0);
                limitemax += 1;
            }

        }
    }
}
