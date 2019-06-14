using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    
    private float currentScale = 0;
    [SerializeField]private float baseScaleModifier = 0.0005f;
    private Coroutine currentCoroutine;
    private bool coroutineStarted;
    /// <summary>
    /// Increase scale by taking snoww on the ground
    /// </summary>
    public void IncreaseScale()
    {
        transform.localScale += new Vector3(baseScaleModifier, baseScaleModifier, 0);
        currentScale++;
    }
    /// <summary>
    /// Decrease slower than increasing
    /// </summary>
    /// 

    public void DecreaseByShoot(int Firemode)
    {
        //if (currentScale < 400 * 0.20f)
        {
            switch (Firemode)
            {
                case 0:
                    currentScale -= currentScale * 0.20f;
                    transform.localScale -= new Vector3(transform.localScale.x*0.2f, transform.localScale.y * 0.2f, 0);
                    break;
                case 1:
                    currentScale -= currentScale * 0.15f;
                    transform.localScale -= new Vector3(transform.localScale.x*0.15f, transform.localScale.x*0.15f, 0);
                    break;
                case 2:
                    currentScale -= currentScale * 0.15f;
                    transform.localScale -= new Vector3(transform.localScale.x*0.15f, transform.localScale.x*0.15f, 0);
                    break;
            }
        }
    }

    private void DecreaseScaleInFire()
    {
        if (transform.localScale.x > 0 && transform.localScale.y > 0){
            transform.localScale -= new Vector3(baseScaleModifier*5f, baseScaleModifier*5, 0);
        }
        currentScale -= 5f;
        if (currentScale <= 0)
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ArenaLimit" && coroutineStarted)
        {
            Debug.Log("StopFire");
            coroutineStarted = false;
            StopCoroutine(currentCoroutine);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ArenaLimit" && !coroutineStarted)
        {
            coroutineStarted = true;
            currentCoroutine = StartCoroutine(InFire());
        }
    }

    IEnumerator InFire()
    {
        while (true)
        {
            Debug.Log("InFire");
            DecreaseScaleInFire();
            yield return new WaitForFixedUpdate();
        }
    }
}
