using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FanLayoutGroup : MonoBehaviour
{
    [SerializeField] Transform _basePosition;
    [SerializeField] int _cardSpace;
    [SerializeField]List<GameObject> _childObjects = new List<GameObject>();
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
        int x = -(transform.childCount / 2 * _cardSpace);
        for (int i = 0; i < transform.childCount; i++)
        {
            var childObject = transform.GetChild(i);
            _childObjects.Add(childObject.gameObject);
            childObject.position = new Vector3(transform.position.x + x, transform.position.y, 0);
            x += _cardSpace;
        }
    }

    public void ShowCard()
    {
        transform.position = new Vector3(transform.position.x, _basePosition.position.y, transform.position.z);
        _cardSpace *= 2;
        SetCard();
    }
}
