using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Right : MonoBehaviour
{
    public Button btn;
    public Text Text;
    public Image image;
    public ServeInfo nowserveInfo;
    public int id;
    
    private void Start()
    {
    }
    public void init(ServeInfo sever)
    { 
    nowserveInfo = sever;
        Text.text="  "+nowserveInfo.id+"Çø "+nowserveInfo.name;
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Login");
        switch (nowserveInfo.state)
        {
            case 0:
                image.gameObject.SetActive(false);
                break;
            case 1:
                image.sprite = atlas.GetSprite("ui_DL_fanhua_01");
                break;
            case 2:
                image.sprite = atlas.GetSprite("ui_DL_huobao_01");
                break;
            case 3:
                image.sprite = atlas.GetSprite("ui_DL_liuchang_01");
                break;
            case 4:
                image.sprite = atlas.GetSprite("ui_DL_weihu_01");
                break;
        }
    }
}
