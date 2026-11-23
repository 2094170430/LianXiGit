using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResPanal : BasePanal
{
    public Button quxiaobtn;
    public Button concretebtn;
    public InputField UsName;
    public InputField UsPw;
    public override void init()
    {
        base.init();
        quxiaobtn.onClick.AddListener(() => { 
        HideMe();
            PanalMag.Instance.ShowPanal<SignPanal>();
        });
        concretebtn.onClick.AddListener(() => {
            //确认账户密码,检查用户是否创建成功
            if (UsName.text.Length >= 6 && UsPw.text.Length >= 6)
            {
                if (SignMrg.Instance.regester(UsName.text, UsPw.text))
                {
                    SignPanal signpanal = PanalMag.Instance.ShowPanal<SignPanal>();
                    signpanal.setUser(UsName.text, UsPw.text);
                    PanalMag.Instance.ShowPanal<TipPanal>().changeText("账户创建成功");

                    SignMrg.Instance.SignData.UsPW=UsPw.text;
                    SignMrg.Instance.SignData.UsName=UsName.text;
                    SignMrg.Instance.Resdata.forontServeID[SignMrg.Instance.SignData.UsName] = 0;
                    SignMrg.Instance.saveSignData();
                    PanalMag.Instance.HindPanal<ResPanal>();
                }
                else
                    PanalMag.Instance.ShowPanal<TipPanal>().changeText("已有用户名");
                
            }
            else
            {
                PanalMag.Instance.ShowPanal<TipPanal>().changeText("账户或密码必须大于等于6个字符");

            }
        });
    }


}
