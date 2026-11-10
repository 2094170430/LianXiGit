using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanalMag : MonoBehaviour
{
    public PanalMag Instance=>instance;
    PanalMag instance  = new PanalMag();//单一实例化
    Dictionary<string, BasePanal> panalDic = new Dictionary<string, BasePanal>();//写存储面板的字典
    Transform canvas;//绑定初始的canvas
    // Start is called before the first frame update
    void Start()
    {
    }
    private PanalMag()
    {
        canvas = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvas.gameObject);
      //构造函数让绑定的Canvas过场景不销毁
    }
    public T ShowPanal<T>()where T : BasePanal
    { 
    string panalname = typeof(T).Name;
        if (panalDic[panalname] != null)
            return panalDic[panalname] as T;
    GameObject panalObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/"+panalname));
        T  panal = panalObj.GetComponent<T>();
        panalDic.Add(panalname, panal);
       panalObj.transform.SetParent(canvas.transform,false);
        panal.ShowMe();
        return panal;
    }
    public void HindPanal<T>(bool isdanchu = true) where T : BasePanal
    {
        if (isdanchu)
        {
            string panalname = typeof(T).Name;
            panalDic[panalname].HideMe();
            Destroy(panalDic[panalname].gameObject);
            panalDic.Remove(panalname);
        }
        else
        {
            string panalname = typeof(T).Name;
            Destroy(panalDic[panalname].gameObject);
            panalDic.Remove(panalname);

        }
    }
    public T GetPanal<T>() where T : BasePanal
    { 
        string panalname = typeof(T).Name;
        if(panalDic.ContainsKey(panalname))
        return panalDic[panalname]as T;
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
