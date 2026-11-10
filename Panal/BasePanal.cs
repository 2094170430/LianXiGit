using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasePanal : MonoBehaviour 
{
     
     bool isalpha;
    public float alphaspeed;
    CanvasGroup canvasg;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        canvasg = this.gameObject.GetComponent<CanvasGroup>();
        if (canvasg == null)
            canvasg = this.gameObject.AddComponent<CanvasGroup>();
    }
    void Start()
    {
       init();
    }
    public virtual void init()
    {
       
    }
    public void HideMe()
    { 
        isalpha = false;
        canvasg.alpha = 1;
    }
    public void ShowMe()
    { 
        isalpha = true;
        canvasg.alpha = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (isalpha)
        {
            canvasg.alpha += alphaspeed*Time.deltaTime;
            if(canvasg.alpha>1)
                canvasg.alpha = 1;
        }
        else
        {
            canvasg.alpha -= alphaspeed * Time.deltaTime;
            if (canvasg.alpha < 0)
                canvasg.alpha = 0;
        }

    }
}
