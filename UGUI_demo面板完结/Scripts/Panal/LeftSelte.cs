using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftSelte : MonoBehaviour
{
    public Button btn;
    public Text text;
    public int Max;//服务器区间
    public int Min;
    private void Start()
    {
        btn.onClick.AddListener(() => { 
        //改变右侧显示的服务器
        });
    }
    public void change(int min,int max)
    { 
        Min = min;
        Max = max;
    text.text = min+"-"+max+"区";//更改显示区间
    }
}
