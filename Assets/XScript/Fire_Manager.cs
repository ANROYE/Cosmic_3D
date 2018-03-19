using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Fire_Manager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool _press = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        _press = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _press = false;
    }
}
