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
    public override void init()
    {
        base.init();
        signdata = SignMrg.Instance.SignData;
        if (signdata != null)
        {
            rempwtog.isOn = signdata.remepw;//读取登录数据
            autologintog.isOn = signdata.autosign;
            if (rempwtog.isOn)
            {
                Usename.text = signdata.UsName;
                UsePassword.text = signdata.UsPW;

            }
            if (autologintog.isOn)
            {
                PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
                                                         //选择服务器面板
            }
        }
        resbtn.onClick.AddListener(() => {
            PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
            //打开注册面板
        });
        concretebtn.onClick.AddListener(() => { 
            //判断账户密码正确性
            PanalMag.Instance.HindPanal<SignPanal>();//隐藏自己
            //选择服务器面板

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
}
