using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Lesson17 : MonoBehaviour
{
    public EventTrigger ent;
    void Start()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((a) => {
            print("~~~鼠标要出来喽~~~");
            PointerEventData handler = a as PointerEventData;
            print("~~~鼠标从"+handler.position+"狠狠出来喽~~~");
        });
        ent.triggers.Add(entry);
    }
    public void PointEnter(BaseEventData evnt)
    {
        print("鼠标进来了欧~~~");
    
    }

    void Update()
    {
        
    }
}
