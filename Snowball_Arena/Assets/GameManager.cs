﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    [SerializeField]private float mapHeight,spriteHeight,mapWidth,spriteWidth, secBeforeShrink;
    [SerializeField]private Transform mapParent;
    [SerializeField]private GameObject snowPrefab;
    private static GameManager _instance;
    public static GameManager Instance{
        get{
			if (_instance == null){
				_instance = GameObject.FindObjectOfType<GameManager>();						
			}		
			return _instance;
		}
    }
    private void Awake(){
        AddSnowToMap();
    }
    private void Start() {
        StartCoroutine(WaitBeforeShrinking());
    }
    /// <summary>
    /// Instantiate the snow prefab based on the map size
    /// </summary>
    private void AddSnowToMap(){
        for(int currentHeightNum = (int)-(mapHeight/spriteHeight)-1; currentHeightNum< (mapHeight/spriteHeight); currentHeightNum++ ){
            for(int currentWidthNum = -(int)(mapWidth/spriteWidth)/2; currentWidthNum< (mapWidth/spriteWidth)/2; currentWidthNum++){  
                Instantiate(snowPrefab,new Vector2((currentWidthNum * spriteWidth)+(spriteWidth/2), (currentHeightNum * spriteHeight)+(spriteWidth/2)), Quaternion.identity,mapParent);
            }
        }
    }

    IEnumerator WaitBeforeShrinking(){
        yield return new WaitForSeconds(secBeforeShrink);
        LimitScript.Instance.canShrink = true;
    }
}
