using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, new Vector2(0, 0),Player.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
