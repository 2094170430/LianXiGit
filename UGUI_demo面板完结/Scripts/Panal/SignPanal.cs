using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPanal : BasePanal
{
    public InputField Usename;//账户输入
    public InputField UsePassword;//密码输入
    public Button resbtn;//注册按钮
    public Button concretebtn;//确认按钮
    public Toggle rempwtog;//记住密码选框
    public Toggle autologintog;//自动登录选框
    SignData signdata ;//登录数据
    public static bool viceautolog=true;
    public override void init()
    {
        base.init();
        signdata = SignMrg.Instance.SignData;
        if (signdata != null)
        {
            rempwtog.isOn = signdata.remepw;//读取登录数据
            autologintog.isOn = signdata.autosign;//自动登录
            if (rempwtog.isOn)
            {
                Usename.text = signdata.UsName;
                UsePassword.text = signdata.UsPW;
            }
            if (autologintog.isOn&&viceautolog)
            {
                PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
                PanalMag.Instance.ShowPanal<ServePanal>();//选择服务器面板
            }
        }
        resbtn.onClick.AddListener(() => {
           
                PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
                PanalMag.Instance.ShowPanal<ResPanal>();
                //打开注册面板
            
          
        });
        concretebtn.onClick.AddListener(() => {
            //判断账户密码正确性
            if (checkUse(Usename.text, UsePassword.text))
            {
                if (SignMrg.Instance.Resdata.forontServeID[signdata.UsName] > 0)//判断是不是第一次进游戏
                {
                    PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
                    SignMrg.Instance.SignData.UsPW = UsePassword.text;
                    SignMrg.Instance.SignData.UsName = Usename.text;
                    SignMrg.Instance.SignData.remepw = rempwtog.isOn;
                    SignMrg.Instance.SignData.autosign = autologintog.isOn;
                    SignMrg.Instance.saveSignData();
                    PanalMag.Instance.ShowPanal<ServePanal>();  //选择服务器面板
                }
                else
                {
                    PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
                    SignMrg.Instance.SignData.UsPW = UsePassword.text;
                    SignMrg.Instance.SignData.UsName = Usename.text;
                    SignMrg.Instance.SignData.remepw = rempwtog.isOn;
                    SignMrg.Instance.SignData.autosign = autologintog.isOn;
                    SignMrg.Instance.saveSignData();
                    PanalMag.Instance.ShowPanal<SelctPanal>();  //选服务面板

                }
                }
        });
        rempwtog.onValueChanged.AddListener((isOn) => {
            if (!isOn)
            { 
            autologintog.isOn = false;
            }

        });
        autologintog.onValueChanged.AddListener((isOn) => {
            if (isOn)
            {
                rempwtog.isOn = true;
            }

        });


    }
    public void setUser(string UsName, string UsPw)
    {
        Usename.text = UsName;
        UsePassword.text= UsPw;
    }
    public bool checkUse(string UsName,string UsPw)
    { 
         ResData resData = SignMrg.Instance.Resdata;
        if (resData.resdata.ContainsKey(UsName))
        {
            if (resData.resdata[UsName] == UsPw)
            {
                //登陆成功
                return true;
            }
            else
            {
                PanalMag.Instance.ShowPanal<TipPanal>().changeText("密码错误");
                return false;
            }
        }
        else
        {
            PanalMag.Instance.ShowPanal<TipPanal>().changeText("没有此用户");
            return false;
        }
    
    
    }
}
