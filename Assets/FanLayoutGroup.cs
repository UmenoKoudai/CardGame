using System.Collections.Generic;
using UnityEngine;

public class FanLayoutGroup : MonoBehaviour
{
    [SerializeField] Transform _showPosition;
    [SerializeField] Transform _base;
    [SerializeField] int _cardSpace;
    Vector3 _basePosition;
    bool _isShow = false;

    private void Start()
    {
        _basePosition = new Vector3(_base.position.x, _base.position.y, _base.position.z);
    }

    public void CardClick()
    {
        _isShow = !_isShow;
        if(_isShow)
        {
            transform.position = _showPosition.position;
        }
        else
        {
            transform.position = _basePosition;
        }
    }
}
