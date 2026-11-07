using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lesson16 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,IPointerClickHandler,IBeginDragHandler,IDragHandler
{
    float time;
    int Hp=0;
    bool isdown = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isdown = true;
        print("开始蓄能");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isdown = false;
        print("结束蓄能");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdown)
        {
            time += Time.deltaTime;
            if (time >= 0.5f)
            { 
            time = 0;
                Hp += 10;
                print("蓄能成功Hp=="+Hp);
            
            }
        
        }
        else 
        {
            if (time > 0.2f)
            { print("蓄能失败"); }
            time = 0;

        }
        
    }
}
