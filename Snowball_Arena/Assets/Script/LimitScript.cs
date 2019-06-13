using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitScript : MonoBehaviour
{   
    private Transform limitTransform;
    public bool canShrink{get;set;}=false;
    private static LimitScript _instance;
    public static LimitScript Instance{
        get{
			if (_instance == null){
				_instance = GameObject.FindObjectOfType<LimitScript>();						
			}		
			return _instance;
		}
    }

    private void Awake() {
        limitTransform = this.gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate() {
        if(canShrink){
            limitTransform.localScale -= new Vector3(0.001f,0.001f,0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerBaseScale"){
            Debug.Log("Lose");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Snow"){
            Destroy(other.gameObject);
            //Change sprite instead?
        }       
    }
}
