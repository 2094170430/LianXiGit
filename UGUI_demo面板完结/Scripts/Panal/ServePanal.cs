using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServePanal : BasePanal
{
    public Button huanqubtn;
    public Button startbtn;
    public Button returnbtn;
    public Text text;

    public override void init()
    {
        base.init();
       text.text= SignMrg.Instance.ServeData[SignMrg.Instance.Resdata.forontServeID[SignMrg.Instance.SignData.UsName] - 1].name;
        huanqubtn.onClick.AddListener(() => {
            PanalMag.Instance.HindPanal<ServePanal>();//隐藏自己
            //打开换区面板
            PanalMag.Instance.ShowPanal<SelctPanal>();
        });
        startbtn.onClick.AddListener(() => {
            PanalMag.Instance.HindPanal<ServePanal>();//隐藏自己
            SignMrg.Instance.saveSignData();
            SceneManager.LoadScene("GameScene");    //打开游戏场景
        
        });
        returnbtn.onClick.AddListener(() => { 
            PanalMag.Instance.HindPanal<ServePanal>();//隐藏自己
            SignPanal.viceautolog=false;
            PanalMag.Instance.ShowPanal<SignPanal>();

});

            
    }
}
