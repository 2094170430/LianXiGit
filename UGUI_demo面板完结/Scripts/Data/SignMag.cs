using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SignMrg 
{
  static SignMrg instance = new SignMrg();
    static public SignMrg Instance =>instance;
   SignData signdata ;//登录数据
   ResData resdata ;//注册数据
    public SignData SignData =>signdata;
    public ResData Resdata=>resdata;//注册数据

     List<ServeInfo> serveData ;
     public List<ServeInfo> ServeData =>serveData;//服务器数据

    SignMrg()//构造函数开局直接从json里读取数据
    {
        signdata = JsonMgr.Instance.LoadData<SignData>("SignData")??new SignData();
        resdata = JsonMgr.Instance.LoadData<ResData>("ResData")??new ResData();
        serveData = JsonMgr.Instance.LoadData<List<ServeInfo>>("ServeInfo") ?? new List<ServeInfo>();


    }
    public void saveSignData()//把数据保存到Json里
    {
        JsonMgr.Instance.SaveData(signdata,"SignData");
        JsonMgr.Instance.SaveData(resdata, "ResData");
        JsonMgr.Instance.SaveData(serveData, "ServeInfo");

    }
    public void clearSignData()//清空登录数据
    { 
    signdata.autosign = false;
        signdata.remepw = false;
        SignMrg.Instance.Resdata.forontServeID[SignMrg.Instance.SignData.UsName] = 0;
        signdata.UsName = null;
        signdata.UsPW = null;

    
    }
    public bool regester(string UsName, string UsPw)//注册方法
    {
        if (resdata.resdata.ContainsKey(UsName))//判断有没有这个用户
        {

            return false;
        }
        else
        {
            resdata.resdata.Add(UsName,UsPw);
            resdata.forontServeID.Add(UsName,0);

            saveSignData();
            return true;
        }
    }
   
}
