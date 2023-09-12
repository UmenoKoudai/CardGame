using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _playerTotalCost;
    [SerializeField] Text _costText;

    public int PlayerTotalCost => _playerTotalCost;
    void Start()
    {
        
    }

    void Update()
    {
        _costText.text = _playerTotalCost.ToString();
    }
}
