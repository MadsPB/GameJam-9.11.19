using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InputManager : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public event Action<Vector2> PointerDown;
    public event Action<Vector2> PointerUp;
    public event Action<Vector2> Drag;

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown?.Invoke(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerUp?.Invoke(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Drag?.Invoke(eventData.position);
    }
}