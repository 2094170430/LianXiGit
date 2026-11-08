using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class Lesson17YaoGan : MonoBehaviour
{
    public float speed = 1f;//物体移速
    public GameObject O;
    public Image obj;            // 摇杆头（拖这个 Image 进来）
    public float radius = 60f;   // 最大偏移半径（UI 本地单位）

    private Vector2 homePos;         // 摇杆头原位
    private Vector2 startPointer;    // 按下时指针位置（父级本地坐标）
    public Vector2 Direction { get; private set; }  // 输出方向，-1~1

    public void beginDrag(BaseEventData a)
    {
        var p = a as PointerEventData;
        if (p == null) return;

        homePos = obj.rectTransform.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            obj.rectTransform.parent as RectTransform,
            p.position, null, out startPointer);
    }

    public void drag(BaseEventData a)
    {
        var p = a as PointerEventData;
        if (p == null) return;

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                obj.rectTransform.parent as RectTransform,
                p.position, null, out var cur)) return;

        Vector2 offset = cur - startPointer;
        if (offset.magnitude > radius) offset = offset.normalized * radius;

        obj.rectTransform.localPosition = homePos + offset;
        Direction = offset / radius;
    }

    public void endDrag(BaseEventData a)
    {
        obj.rectTransform.localPosition = homePos;
        Direction = Vector2.zero;
    }
    private void Update()
    {
        if (Direction.sqrMagnitude<0.01f)
        {
            return;
        }
        O.transform.rotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.y));
        O.transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}
