using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Storage", menuName = "Card")]
public class CardStorage : ScriptableObject
{
    [SerializeField] List<CardState> _storage = new List<CardState>();

    public List<CardState> Storage => _storage;
}
