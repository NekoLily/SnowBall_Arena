using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float mapHeight, spriteHeight, mapWidth, spriteWidth, secBeforeShrink;
    private Transform mapParent;
    [SerializeField] private GameObject snowPrefab;
    [SerializeField] private GameObject playerPrefab;
    private bool gameIsStarted = false;
    [SerializeField] private Vector2[] spawnPos;
    public int playerNumber{get;set;}= 2;

    private void Update()
    {
        if (gameIsStarted)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1);
            {
                gameIsStarted = false;
            }
        }
    }

    public void IncreasePlayerNumber()
    {
        if (playerNumber < 4)
        {
            playerNumber++;
            GameObject.Find("NumberPlayerText").GetComponent<Text>().text = playerNumber.ToString();
        }
    }

    public void DecreasePlayerNumber()
    {
        if (playerNumber > 2)
        {
            playerNumber--;
            GameObject.Find("NumberPlayerText").GetComponent<Text>().text = playerNumber.ToString();
        }
    }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    /// <summary>
    /// Instantiate the snow prefab based on the map size
    /// </summary>
    private void AddSnowToMap()
    {
        for (int currentHeightNum = (int)-(mapHeight / spriteHeight) - 1; currentHeightNum < (mapHeight / spriteHeight); currentHeightNum++)
        {
            for (int currentWidthNum = -(int)(mapWidth / spriteWidth) / 2; currentWidthNum < (mapWidth / spriteWidth) / 2; currentWidthNum++)
            {
                Instantiate(snowPrefab, new Vector2((currentWidthNum * spriteWidth) + (spriteWidth / 2), (currentHeightNum * spriteHeight) + (spriteWidth / 2)), Quaternion.identity, mapParent);
            }
        }
    }

    IEnumerator WaitBeforeShrinking()
    {
        Text TMP = GameObject.Find("CountText").GetComponent<Text>();
        yield return new WaitForSeconds(1f);
        TMP.text = "3";
        yield return new WaitForSeconds(1f);
        TMP.text = "2";
        yield return new WaitForSeconds(1f);
        TMP.text = "1";
        yield return new WaitForSeconds(1f);
        TMP.text = "Start !";
        GameObject[] playerArray = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in playerArray)
            player.GetComponent<PlayerScript>()._PlayerState = PlayerState.Moving;
        gameIsStarted = true;
        yield return new WaitForSeconds(0.5f);
        TMP.text = "";       
        yield return new WaitForSeconds(secBeforeShrink);
        LimitScript.Instance.canShrink = true;
    }

    public void SetupGame()
    {    
        mapParent = GameObject.Find("Map").GetComponent<Transform>();
        spawnPos = new Vector2[playerNumber];
        spawnPos = FindChildVector2(GameObject.Find("SpawnPos").GetComponent<Transform>());
        AddSnowToMap();
        for (int i = 0; i < playerNumber; i++)
        {
            GameObject tmpGameObject = Instantiate(playerPrefab, spawnPos[i], playerPrefab.transform.rotation);
            tmpGameObject.GetComponent<PlayerScript>().playerKeyCode = KeyCodeSave.Instance.GiveOneDimension(i);
        }
        StartCoroutine(WaitBeforeShrinking());
    }

    private Vector2[] FindChildVector2(Transform parentTransform){
        int currentChild = 0;
        Vector2[] tmpChildVector2 = new Vector2[playerNumber];
        foreach (Transform transform in parentTransform) {
            if (transform != parentTransform){
                tmpChildVector2[currentChild] = transform.position;
                currentChild++;
                if(currentChild == playerNumber){
                    break;
                }
            }
        }  
        return tmpChildVector2;         
    }
}
