using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lesson6_1 : MonoBehaviour
{
  static public Lesson6_1 instance = new Lesson6_1();
    // Start is called before the first frame update
    public Rect btn1pos = new Rect(0,0,100,100);
    public Rect btn2pos = new Rect(0, 0, 100, 100);
    public Rect windowpos = new Rect(0, 0, 500, 500);
    public GUIStyle style = new GUIStyle();
    public Rect r = new Rect();
    private void windowf1(int i)
    {
        switch (i)
        { 
        case 1:
                GUI.DragWindow(new Rect(0,0,1000,60));

                if (GUI.Button(btn1pos, "确认退出", style))
                {
                   Application.Quit(0);
                }
                if (GUI.Button(btn2pos, "取消退出", style))
                {
                    GameMenu.gamemenu.Active();
                    Hide();
                }
                break;
                case 2:
                break;
        
        }
    
    }
    private void Awake()
    {
        instance = this;
        Hide();

    }
    public void Hide()
    { 
    this.gameObject.SetActive(false);
    }
    public void Show()
    { 
    this .gameObject.SetActive(true);
    }
    private void OnGUI()
    {
       windowpos = GUI.Window(1, windowpos, windowf1, "确认选择");
    }

}
