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
    [SerializeField]
    private GameObject snowBallMultiShootPrefab,snowBallBigShootPrefab,snowBallPiercingShootPrefab;
    public PlayerState _PlayerState = PlayerState.Moving;
    private float shootForce;
    [SerializeField]
    private float defaultShootForce = 10,offsetIncreaseShootForce = 10, maxShootForce = 100;

    private float chargeForce;
    [SerializeField]
    private float defaultChargeForce = 10,offsetIncreaseChargeForce = 10,maxChargeForce = 100;
    private float Trigger = 0;
    private int FireMode = 0;
    public string[] playerKeyCode = new string[7];
    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        shootForce = defaultShootForce;
        chargeForce = defaultChargeForce;
    }


    private void FixedUpdate()
    {
        Vector2 MoveDirection = new Vector2(Input.GetAxis(playerKeyCode[0]), Input.GetAxis(playerKeyCode[1]));
        Vector2 TargetDirection = new Vector2(Input.GetAxis(playerKeyCode[5]), Input.GetAxis(playerKeyCode[6]));

        float LeftBumper = Input.GetAxis(playerKeyCode[3]);
        float RightBumper = Input.GetAxis(playerKeyCode[4]);

        Trigger = Input.GetAxis(playerKeyCode[2]);

        ChangeFireMode(LeftBumper, RightBumper);
        MoveSnowBall(MoveDirection);
        Shoot(TargetDirection);
    }

    private void MoveSnowBall(Vector2 Direction)
    {
        if (Trigger == -1 && _PlayerState == PlayerState.Moving)
        {        
            if (chargeForce < maxChargeForce)
                chargeForce += offsetIncreaseChargeForce;
            _PlayerState = PlayerState.LoadingCharge;
        }
        else if (Trigger == 0 && _PlayerState == PlayerState.LoadingCharge)
        {           
            _Rigidbody2D.AddForce(Direction * chargeForce);
            chargeForce = defaultChargeForce;
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
            if (shootForce < maxShootForce)
                shootForce += offsetIncreaseShootForce;
            _PlayerState = PlayerState.LoadingShoot;
        }
        else if (Trigger == 0 && _PlayerState == PlayerState.LoadingShoot)
        {
            GameObject SnowBall;
            switch (FireMode)
            {
                case 0:
                    SnowBall = Instantiate<GameObject>(snowBallBigShootPrefab, transform.position, transform.rotation);
                    SnowBall.GetComponent<Rigidbody2D>().AddForce(TargetDirection * shootForce);                   
                    break;
                case 1:
                    SnowBall = Instantiate<GameObject>(snowBallMultiShootPrefab, transform.position, transform.rotation);
                    foreach(Rigidbody2D multishoot in SnowBall.GetComponentsInChildren<Rigidbody2D>())
                    {
                        multishoot.AddForce(TargetDirection * shootForce);
                    }
                    
                    break;

                case 2:
                    SnowBall = Instantiate<GameObject>(snowBallPiercingShootPrefab, transform.position, transform.rotation);
                    SnowBall.GetComponent<Rigidbody2D>().AddForce(TargetDirection * shootForce);
                    break;
            }
            GetComponent<Scale>().DecreaseByShoot(FireMode);          
            shootForce = defaultShootForce;
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

}
