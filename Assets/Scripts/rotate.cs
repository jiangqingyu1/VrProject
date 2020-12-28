using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotate : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>
    /// 需要旋转的模型
    /// </summary>
    public Transform model;
    /// <summary>
    /// 父物体的recttransform
    /// </summary>
    public RectTransform parentRect;
    /// <summary>
    /// 旋转的UI
    /// </summary>
    public RectTransform img;
    /// <summary>
    /// 摄像机
    /// </summary>
    public Camera cam;
    /// <summary>
    /// 是否在拖拽
    /// </summary>
    private bool drag = false;
    /// <summary>
    /// 初始角度
    /// </summary>
    private float originAngle = 0;
    /// <summary>
    /// 自身角度
    /// </summary>
    private float selfAngle1 = 0;
    /// <summary>
    /// 上一次和当前的角度
    /// </summary>
    private float lastAngle = 0f;
    private float currentAngle = 0f;
    /// <summary>
    /// 上一次和当前的位置
    /// </summary>
    private Vector2 currentPos;
    private Vector2 lastPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        drag = true;

        originAngle = GetAngle(eventData.position);

        selfAngle1 = (img.transform as RectTransform).eulerAngles.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (drag)
        {
            lastAngle = currentAngle;
            currentAngle = GetAngle(eventData.position);

            float val = TouchJudge(currentPos, ref lastPos, Vector2.zero);
            if (val > 0f && val < 180f)
            {
                img.eulerAngles = new Vector3(0f, 0f, -currentAngle + originAngle + selfAngle1);
             
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        drag = false;
    }
    /// <summary>
    /// 将屏幕坐标转成UI坐标
    /// </summary>
    /// <param name="pos1"></param>
    /// <returns></returns>
    float GetAngle(Vector2 pos1)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, pos1, cam, out pos);
        currentPos = pos;
        return Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
    }
    /// <summary>
    /// 判断顺时针还是逆时针旋转
    /// </summary>
    /// <param name="current"></param>
    /// <param name="last"></param>
    /// <param name="anchor"></param>
    /// <returns></returns>
    private float TouchJudge(Vector2 current, ref Vector2 last, Vector2 anchor)
    {
        Vector2 lastDir = (last - anchor).normalized;
        Vector2 currentDir = (current - anchor).normalized;

        float lastDot = Vector2.Dot(Vector2.right, lastDir);
        float currentDot = Vector2.Dot(Vector2.right, currentDir);

        float lastAngle = last.y < anchor.y
        ? Mathf.Acos(lastDot) * Mathf.Rad2Deg
        : -Mathf.Acos(lastDot) * Mathf.Rad2Deg;

        float currentAngle = current.y < anchor.y
        ? Mathf.Acos(currentDot) * Mathf.Rad2Deg
        : -Mathf.Acos(currentDot) * Mathf.Rad2Deg;

        last = current;
        return currentAngle - lastAngle;
    }
}