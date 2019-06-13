using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float currentScale = 0;
    private Coroutine currentCoroutine;
    private bool coroutineStarted;
    /// <summary>
    /// Increase scale by taking snoww on the ground
    /// </summary>
    public void IncreaseScale()
    {
        if (currentScale <= 200)
        {
            transform.localScale += new Vector3(0.08F, 0.08F, 0);
            currentScale++;
        }
        else if (currentScale <= 400)
        {
            transform.localScale += new Vector3(0.04F, 0.04F, 0);
            currentScale++;
        }
    }
    /// <summary>
    /// Decrease slower than increasing
    /// </summary>
    /// 

    public void DecreaseByShoot(int Firemode)
    {
        if (currentScale < 400 * 0.20f)
        {
            switch (Firemode)
            {
                case 0:
                    currentScale = currentScale * 0.80f;
                    transform.localScale -= new Vector3(0.06F, 0.06F, 0);
                    break;
                case 1:
                    currentScale = currentScale * 0.90f;
                    transform.localScale -= new Vector3(0.04F, 0.04F, 0);
                    break;
                case 2:
                    currentScale = currentScale * 0.90f;
                    transform.localScale -= new Vector3(0.04F, 0.04F, 0);
                    break;
            }
        }
    }

    private void DecreaseScaleInFire()
    {
        if (currentScale > 200)
        {
            transform.localScale -= new Vector3(0.05F, 0.05F, 0);
            currentScale -= 0.5f;
        }
        else if (currentScale > 0)
        {
            transform.localScale -= new Vector3(0.06F, 0.06F, 0);
            currentScale -= 0.5f;
        
        }
        if (currentScale<=0)
        {
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
