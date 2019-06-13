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
    public GameObject SnowBallMultiShootPrefab;
    public GameObject SnowBallBigShootPrefab;
    public GameObject SnowBallPiercingShootPrefab;
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
    private int FireMode = 0;

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

        float LeftBumper = Input.GetAxis("LeftBumper");
        float RightBumper = Input.GetAxis("RightBumper");

        Trigger = Input.GetAxis("Trigger");

        ChangeFireMode(LeftBumper, RightBumper);
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
            GameObject SnowBall;
            switch (FireMode)
            {
                case 0:
                    SnowBall = Instantiate<GameObject>(SnowBallBigShootPrefab, transform.position, transform.rotation);
                    SnowBall.GetComponent<Rigidbody2D>().AddForce(TargetDirection * ShootForce);                   
                    break;
                case 1:
                    SnowBall = Instantiate<GameObject>(SnowBallMultiShootPrefab, transform.position, transform.rotation);
                    foreach(Rigidbody2D multishoot in SnowBall.GetComponentsInChildren<Rigidbody2D>())
                    {
                        multishoot.AddForce(TargetDirection * ShootForce);
                    }
                    
                    break;

                case 2:
                    SnowBall = Instantiate<GameObject>(SnowBallPiercingShootPrefab, transform.position, transform.rotation);
                    SnowBall.GetComponent<Rigidbody2D>().AddForce(TargetDirection * ShootForce);
                    break;
            }
            GetComponent<Scale>().DecreaseByShoot(FireMode);          
            ShootForce = DefaultShootForce;
            _PlayerState = PlayerState.Moving;
        }
    }

    private void ChangeFireMode(float LeftB, float RightB)
    {
        if (LeftB == 1 && RightB == 1)
            return;
        else if (LeftB == 1)
        {
            if (FireMode == 0)
                FireMode = 2;
            else
                FireMode--;
        }
        else if (RightB == 1)
        {
            if (FireMode == 2)
                FireMode = 0;
            else
                FireMode++;
        }
    }

    public void ChangeKeyCode(string[] thisPlayerKeyCode){
        
    }
}
