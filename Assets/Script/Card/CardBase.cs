using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardBase : FieldData, IDragHandler
{
    [SerializeField] Sprite _cardImage;
    [SerializeField] int _cost;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
