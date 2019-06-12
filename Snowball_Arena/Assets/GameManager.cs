using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance{
        get{
			if (_instance == null){
				_instance = GameObject.FindObjectOfType<GameManager>();						
			}		
			return _instance;
		}
    }
    private void Awake() {
        for(int currentHeightNum = 0;currentheightNum< mapHeight/spriteHeight; currentheightNum++ ){
            for(int currentWidthNum = 0; currentWidthNum< mapWidth/spriteWidth; currentWidthNum++){  
                
            }
        }
    }
}
