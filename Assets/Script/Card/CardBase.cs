using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBase : FieldData, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] Sprite _cardImage;
    [SerializeField] int _cost;
    GameObject _playerField;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _playerField = GetField(eventData);
        if (_playerField)
        {
            Debug.Log($"{_playerField.name}ÇÃè„Ç…Ç¢Ç‹Ç∑");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_playerField)
        {
            transform.SetParent(_playerField.transform);
        }
    }

    GameObject GetField(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        RaycastResult result = default;
        foreach(var r in results)
        {
            if(r.gameObject.tag == "PlayerField")
            {
                result = r;
            }
        }
        return result.gameObject;
    }
}
