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

    private void OnTriggerExit2D(Collider2D Collision)
    {
        Debug.Log(Collision.gameObject);
        if (Collision.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
