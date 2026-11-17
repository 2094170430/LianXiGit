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

    public override void init()
    {
        base.init();
        huanqubtn.onClick.AddListener(() => {
            PanalMag.Instance.HindPanal<ServePanal>();//隐藏自己
            //打开换区面板

        });
        startbtn.onClick.AddListener(() => {
            PanalMag.Instance.HindPanal<ServePanal>();//隐藏自己
            //SceneManager.LoadScene("Gamescene");    //打开游戏场景
        
        });
        returnbtn.onClick.AddListener(() => { 
            PanalMag.Instance.HindPanal<ServePanal>();//隐藏自己
            PanalMag.Instance.ShowPanal<SignPanal>();
        });

            
    }
}
