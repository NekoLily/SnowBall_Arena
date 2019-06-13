using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public int currentScale = 0;
    public void IncreaseScale()
    {
        if (currentScale <= 200)
        {
            Debug.Log("devient gros");
            transform.localScale += new Vector3(0.12F, 0.12F, 0);
            currentScale += 1;
        }
        else if (currentScale <= 400)
        {
            Debug.Log("devient gros mais moins vite");
            transform.localScale += new Vector3(0.10F, 0.10F, 0);
            currentScale += 1;
        }
    }
}
