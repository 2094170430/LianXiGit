using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignMrg 
{
  static SignMrg instance = new SignMrg();
    static public SignMrg Instance =>instance;
    SignData signdata ;
    public SignData SignData =>signdata;
     SignMrg()
    {
        signdata = JsonMgr.Instance.LoadData<SignData>("SignData")??new SignData();
    
    }
    public void saveSignData()
    {
        JsonMgr.Instance.SaveData(signdata,"SignData");
    
    }
}
