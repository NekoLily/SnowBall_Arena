using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    protected Rigidbody2D _Rigidbody2D;
     private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        MoveSnowBall(X, Y);
    }

    private void MoveSnowBall(float X, float Y)
    {
        Debug.Log(X + " " + Y);
        _Rigidbody2D.AddForce(new Vector2(X, Y));
    }

    private void Shoot()
    {

    }
}
