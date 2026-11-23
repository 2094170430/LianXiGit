using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasePanal : MonoBehaviour 
{
     
     bool isalpha;
    public float alphaspeed =1f;
    CanvasGroup canvasg;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        canvasg = this.gameObject.GetComponent<CanvasGroup>();
        if (canvasg == null)
            canvasg = this.gameObject.AddComponent<CanvasGroup>();
    }
    protected virtual void Start()
    {
       init();
    }
    public  virtual void init()
    {
       
    }
    public virtual void HideMe()
    { 
        isalpha = false;
        canvasg.alpha = 1;
    }
    public virtual void ShowMe()
    { 
        isalpha = true;
        canvasg.alpha = 0;

    }
    // Update is called once per frame
    protected virtual void Update()
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
