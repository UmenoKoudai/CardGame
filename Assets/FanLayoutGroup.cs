using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanLayoutGroup : MonoBehaviour
{
    [SerializeField] Transform _basePosition;
    [SerializeField] int _cardSpace;
    List<GameObject> _childObjects = new List<GameObject>();

    private void Start()
    {
        int x = -(transform.childCount / 2 * _cardSpace);
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var childObject = transform.GetChild(i);
                _childObjects.Add(childObject.gameObject);
                childObject.position = new Vector3(transform.position.x +  x, transform.position.y + 20.0f, 0);
                x += _cardSpace;
            }
        }
    }
}
