using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSetup : MonoBehaviour
{
    private void Awake() {
        GameManager.Instance.SetupGame();
    }
}
