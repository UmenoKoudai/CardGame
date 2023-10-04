using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FanLayoutGroup : FieldData
{
    [SerializeField] Transform _showPosition;
    [SerializeField] Transform _base;
    RectTransform _rectTransform;
    Vector3 _basePosition;
    float _cardPosition;
    float _cardSpace;
    int _center;
    int _nowHandNum;
    bool _isShow = false;

    private void Start()
    {
        _cardSpace = (transform.childCount - 3) * -18;
        _rectTransform = GetComponent<RectTransform>();
        CardSetting();
        _basePosition = new Vector3(_base.position.x, _base.position.y, _base.position.z);
    }
    private void Update()
    {
        if(_nowHandNum < transform.childCount || _nowHandNum > transform.childCount)
        {
            CardSetting();
        }
        _nowHandNum = transform.childCount;
    }

    public void CardSetting()
    {
        RectTransform[] cardTransforms = new RectTransform[transform.childCount];
        _center = transform.childCount / 2;
        _cardPosition = _center * (-160 - _cardSpace);
        for(int i = 0; i < transform.childCount; i++)
        {
            cardTransforms[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
        foreach (var card in cardTransforms)
        {
            card.position = new Vector2(_rectTransform.position.x + _cardPosition, _rectTransform.position.y);
            _cardPosition += 160 + _cardSpace;
        }
    }

    public void CardClick()
    {
        _isShow = !_isShow;
        if(_isShow)
        {
            _cardSpace = (transform.childCount - 3) * -2;
            transform.position = _showPosition.position;
            CardSetting();
        }
        else
        {
            _cardSpace = (transform.childCount - 3) * -18;
            transform.position = _basePosition;
            CardSetting();
        }
    }
}
