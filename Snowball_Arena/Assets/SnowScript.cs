using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowScript : MonoBehaviour
{
    public int snowStack{get;set;}=4;
    private SpriteRenderer _sprite;
    private void Awake() {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && snowStack > 0){
            snowStack--;
            Color tmpColor = new Color(_sprite.color.r,_sprite.color.g,_sprite.color.b, snowStack/4f);
            _sprite.color = tmpColor;
            //UpdateSprite();
        }
    }

    private void UpdateSprite(){
        switch (snowStack){
            case 0:
                break;
        }
    }
}
