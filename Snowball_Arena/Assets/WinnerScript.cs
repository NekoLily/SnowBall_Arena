using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] colorPlayers;
    [SerializeField] private Color[] playerColorArray = { Color.blue, Color.green, Color.yellow, Color.magenta };
    public void Awake()
    {
        
        string TMP = GameManager.Instance.winnerName;
        GameObject.Find("WinnerText").GetComponent<Text>().text = TMP + " Win !";
        
        switch (TMP)
        {
            case "Player 1":
                GameObject.Find("boule").GetComponent<SpriteRenderer>().color = playerColorArray[0];
                break;
            case "Player 2":
                GameObject.Find("boule").GetComponent<SpriteRenderer>().color = playerColorArray[1];
                break;
            case "Player 3":
                GameObject.Find("boule").GetComponent<SpriteRenderer>().color = playerColorArray[2];
                break;
            case "Player 4":
                GameObject.Find("boule").GetComponent<SpriteRenderer>().color = playerColorArray[3];
                break;
        }
    }
}
