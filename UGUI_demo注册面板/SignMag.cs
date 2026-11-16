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

    SignMrg()
    {
        signdata = JsonMgr.Instance.LoadData<SignData>("SignData")??new SignData();
        resdata = JsonMgr.Instance.LoadData<ResData>("ResData")??new ResData();

    }
    public void saveSignData()
    {
        JsonMgr.Instance.SaveData(signdata,"SignData");
        JsonMgr.Instance.SaveData(resdata, "ResData");

    }
 
    public bool regester(string UsName, string UsPw)
    {
        if (resdata.resdata.ContainsKey(UsName))
        {

            return false;
        }
        else
        {
            resdata.resdata.Add(UsName,UsPw);
            saveSignData();
            return true;
        }
    }
   
}
