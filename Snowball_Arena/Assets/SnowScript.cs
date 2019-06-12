using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowScript : MonoBehaviour
{
    public int snowStack{get;set;}=4;
    private Color _spriteAlpha;
    private void Awake() {
        _spriteAlpha = this.gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && snowStack > 0){
            snowStack--;
            _spriteAlpha.a = snowStack/4;
            UpdateSprite();
        }
    }

    private void UpdateSprite(){
        switch (snowStack){
            case 0:
                break;
        }
    }
}
