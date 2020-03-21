using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{

    public int points;
    public int hitsToBrake;
    public Sprite hitSprite;

   public void BreakeBrick()
    {
        hitsToBrake--;
        GetComponent<SpriteRenderer> (). sprite = hitSprite;
    }
}
