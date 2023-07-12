using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FanLayoutGroup : MonoBehaviour
{
    [SerializeField] Transform _showPosition;
    [SerializeField] int _cardSpace;
    [SerializeField]List<GameObject> _childObjects = new List<GameObject>();
    Vector3 _basePosition;

    private void OnValidate()
    {
        //if (transform.childCount > 0)
        //{
        //    int x = -(transform.childCount / 2 * _cardSpace);
        //    for (int i = 0; i < transform.childCount; i++)
        //    {
        //        var childObject = transform.GetChild(i);
        //        _childObjects.Add(childObject.gameObject);
        //        childObject.position = new Vector3(transform.position.x + x, transform.position.y + 20.0f, 0);
        //        x += _cardSpace;
        //    }
        //}
    }

    private void Start()
    {
        SetCard();
    }

    public void SetCard()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var childObject = transform.GetChild(i);
            _childObjects.Add(childObject.gameObject);
        }SetPosition(transform.position);
    }

    public void SetPosition(Vector3 cardPosition)
    {
        int x = -(transform.childCount / 2 * _cardSpace);
        for (int i = 0; i < transform.childCount; i++)
        {
            var childObject = transform.GetChild(i);
            _childObjects.Add(childObject.gameObject);
            childObject.position = new Vector3(cardPosition.x + x, cardPosition.y, 0);
            x += _cardSpace;
        }
    }

    public void ShowCard()
    {
        _basePosition = transform.position;
        _cardSpace *= 2;
        SetPosition(_showPosition.position);
    }

    public void BaseCard()
    {
        transform.position = _basePosition;
        _cardSpace /= 2;
        SetPosition(transform.position);
    }
}
