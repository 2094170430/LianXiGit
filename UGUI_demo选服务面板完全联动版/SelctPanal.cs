using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class SelctPanal : BasePanal
{
    public ScrollRect lv;
    public ScrollRect rv;//左右滑动视图

    public Text textname; // 服务器选择信息区间

    public Text textold;//上次登录的信息;
    public Button bt;
    public Image imgstate;

    public List<GameObject> buttons = new List<GameObject>();//右侧服务器按钮统一管理

    public override void init()
    {
        base.init();
        List<ServeInfo> list = SignMrg.Instance.ServeData;
        int cum = list.Count / 5;
        if (list.Count % 5 > 0)
            cum++;//要是还有剩下的服务器就多建立一个按钮
        for (int i = 0; i < cum; i++)
        {
            GameObject lbtn = Instantiate(Resources.Load<GameObject>("UI/Left"));
            lbtn.transform.SetParent(lv.content, false);
            int min = i * 5 + 1;
            int max = (i + 1) * 5;
            if (list.Count < max)
                max = list.Count;
            LeftSelte ls = lbtn.GetComponent<LeftSelte>();//获得左侧竖图按钮挂载的代码
            ls.change(min, max);
            ls.btn.onClick.AddListener(()=>
            { 
        UpdatePanal(min,list.Count>max?max:list.Count);
            }
            );
        }
        UpdatePanal(1,list.Count>5?5:list.Count);


    }
    public override void ShowMe()
    {
        base.ShowMe();
       int oldid = SignMrg.Instance.SignData.forontServeID;//上次登录按钮处理
        if (oldid <= 0)
        {
            textold.text = "  无";
            imgstate.gameObject.SetActive(false);
        }
        else
        {
            ServeInfo ser = SignMrg.Instance.ServeData[oldid - 1];//提取上次登录的信息
            textold.text = " "+ser.id+"区  "+ser.name;
            SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Login");
            switch (ser.state)
            {
                case 0:
                    imgstate.gameObject.SetActive(false);
                    break;
                case 1:
                    imgstate.sprite = atlas.GetSprite("ui_DL_fanhua_01");
                    break;
                case 2:
                    imgstate.sprite = atlas.GetSprite("ui_DL_huobao_01");
                    break;
                case 3:
                    imgstate.sprite = atlas.GetSprite("ui_DL_liuchang_01");
                    break;
                case 4:
                    imgstate.sprite = atlas.GetSprite("ui_DL_weihu_01");
                    break;
            }
        }//上次登录逻辑



    }
    public override void HideMe()
    {
        base.HideMe();

    }
    public void UpdatePanal(int min, int max)
    {
    textname.text = min + "-" + max+"区";
        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i]);
        }
        buttons.Clear();//删除旧表内容
        for (int i = min; i <= max; i++)//加新表
        {
            int ii = i;//记录当前区，防压包；
        GameObject gameObject = Instantiate(Resources.Load<GameObject>("UI/Right"));//创建服务器
            gameObject.transform.SetParent(rv.content, false);
         Right right = gameObject.GetComponent<Right>();
            right.btn.onClick.AddListener(() => {
                SignMrg.Instance.SignData.forontServeID = ii;//设置上次登录的服务区
                SignMrg.Instance.saveSignData();
                PanalMag.Instance.HindPanal<SelctPanal>();//隐藏自己
               ServePanal sp = PanalMag.Instance.ShowPanal<ServePanal>();//显示服务器面板
                sp.text.text = right.Text.text;
            });
            ServeInfo ser = SignMrg.Instance.ServeData[i - 1];
            right.init(ser);
            buttons.Add(gameObject);
        }


    }


}
