using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Moving, Pause, LoadingCharge, LoadingShoot,
}

public class PlayerScript : MonoBehaviour
{
    protected Rigidbody2D _Rigidbody2D;
    public GameObject SnowBallShootPrefab;
    public PlayerState _PlayerState = PlayerState.Moving;

    float ShootForce;
    public float DefaultShootForce = 10;
    public float OffsetIncreaseShootForce = 10;
    public float MaxShootForce = 100;

    float ChargeForce;
    public float DefaultChargeForce = 10;
    public float OffsetIncreaseChargeForce = 10;
    public float MaxChargeForce = 100;

    private float Trigger = 0;

    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        ShootForce = DefaultShootForce;
        ChargeForce = DefaultChargeForce;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 TargetDirection = new Vector2(Input.GetAxis("HorizontalTarget"), Input.GetAxis("VerticalTarget"));

        Trigger = Input.GetAxis("Trigger");

        MoveSnowBall(MoveDirection);
        Shoot(TargetDirection);
    }

    private void MoveSnowBall(Vector2 Direction)
    {
        if (Trigger == -1 && _PlayerState == PlayerState.Moving)
        {        
            if (ChargeForce < MaxChargeForce)
                ChargeForce += OffsetIncreaseChargeForce;
            _PlayerState = PlayerState.LoadingCharge;
        }
        else if (Trigger == 0 && _PlayerState == PlayerState.LoadingCharge)
        {           
            _Rigidbody2D.AddForce(Direction * ChargeForce);
            ChargeForce = DefaultChargeForce;
            _PlayerState = PlayerState.Moving;
        }
        else if (Trigger == 0 && _PlayerState == PlayerState.Moving)
            _Rigidbody2D.AddForce(Direction);

    }

    private void Shoot(Vector2 TargetDirection)
    {
        Debug.Log(Trigger + " " + _PlayerState);
        if (Trigger == 1 && _PlayerState == PlayerState.Moving)
        {          
            if (ShootForce < MaxShootForce)
                ShootForce += OffsetIncreaseShootForce;
            _PlayerState = PlayerState.LoadingShoot;
        }
        else if (Trigger == 0 && _PlayerState == PlayerState.LoadingShoot)
        {            
            GameObject SnowBall = Instantiate<GameObject>(SnowBallShootPrefab, transform.position, transform.rotation);
            SnowBall.GetComponent<Rigidbody2D>().AddForce(TargetDirection * ShootForce);
            ShootForce = DefaultShootForce;
            _PlayerState = PlayerState.Moving;
        }
    }
}
