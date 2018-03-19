using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Input_Manager : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public RectTransform _connect;

    public Vector3 _dir = Vector3.zero;

    public void OnDrag(PointerEventData eventData)
    {
        _dir = _connect.transform.localPosition.normalized;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dir = Vector3.zero;
    }
}