using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballAmmoScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
}
