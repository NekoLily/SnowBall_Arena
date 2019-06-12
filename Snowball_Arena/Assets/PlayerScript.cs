using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle, Pause, Moving, Loading,
}

public class PlayerScript : MonoBehaviour
{
    protected Rigidbody2D _Rigidbody2D;
    public GameObject SnowBallShootPrefab;
    public PlayerState _PlayerState = PlayerState.Idle;

    
    public float DefaultShootForce = 10;
    float ShootForce;
    public float IncreaseShootForce = 10;
    public float MaxShootForce = 100;

    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        ShootForce = DefaultShootForce;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 TargetDirection = new Vector2(Input.GetAxis("HorizontalTarget"), Input.GetAxis("VerticalTarget"));

        float TriggerShoot = Input.GetAxis("Fire1");
        Debug.Log(TargetDirection);
        MoveSnowBall(MoveDirection);
        Shoot(TriggerShoot, TargetDirection);
    }

    private void MoveSnowBall(Vector2 Direction)
    {
        if (_PlayerState == PlayerState.Idle)
            _Rigidbody2D.AddForce(Direction);
    }

    private void Shoot(float Trigger, Vector2 TargetDirection)
    {
        if (Trigger == 1)
        {
            _PlayerState = PlayerState.Loading;
            if (ShootForce < MaxShootForce)
            ShootForce += IncreaseShootForce;
        }
        if (Trigger == 0 && _PlayerState == PlayerState.Loading)
        {
            _PlayerState = PlayerState.Idle;
            GameObject SnowBall = Instantiate<GameObject>(SnowBallShootPrefab, transform.position, transform.rotation);
            SnowBall.GetComponent<Rigidbody2D>().AddForce(TargetDirection * ShootForce);
            ShootForce = DefaultShootForce;
        }
    }
}
