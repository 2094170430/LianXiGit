using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Lesson15 : MonoBehaviour
{
    // Start is called before the first frame update
    public Image i;
    void Start()
    {
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("MyAtlas");
      Sprite s=  atlas.GetSprite("bk");
        i.sprite = s;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
