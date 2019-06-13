using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowScript : MonoBehaviour
{
    public int snowStack{get;set;}=4;
    private bool inZone;
    private SpriteRenderer _sprite;
    private void Awake() {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        inZone =false;
    }
    /// <summary>
    /// Change snow transparency/sprite based on snowStack value
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && snowStack > 0 && inZone){
            snowStack--;
            Color tmpColor = new Color(_sprite.color.r,_sprite.color.g,_sprite.color.b, snowStack/4f);
            _sprite.color = tmpColor;
            //UpdateSprite();
            other.gameObject.GetComponent<Scale>().IncreaseScale();
        }
    }
    public void GetInZone(){
        Color tmpColor = new Color(_sprite.color.r,_sprite.color.g,_sprite.color.b, 1f);
        _sprite.color = tmpColor;
        inZone = true;
        this.gameObject.tag = "Lave";
    }
    /// <summary>
    /// Change sprite instead of transparency
    /// </summary>
    private void UpdateSprite(){
        switch (snowStack){
            case 0:
                break;
        }
    }
}
