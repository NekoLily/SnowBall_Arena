using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitScript : MonoBehaviour
{   
    private EdgeCollider2D limitCollider;
    public bool canShrink{get;set;}=false;
    public Sprite lave;
    public void Start()
    {
      
    }
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
        limitCollider = this.gameObject.GetComponent<EdgeCollider2D>();
    }
    private void FixedUpdate() {
        if(canShrink){
            limitCollider.edgeRadius += 0.01f;
            if(limitCollider.edgeRadius>9.9f){
                canShrink = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Snow")
        {
            other.gameObject.tag = "Lave";
            other.gameObject.GetComponent<SpriteRenderer>().sprite = lave;
            //Change sprite instead?
        }       
    }
}
