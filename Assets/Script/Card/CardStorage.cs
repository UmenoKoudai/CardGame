using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Card")]
public class CardStorage : ScriptableObject
{
    [SerializeField] List<CardState> _storage;
    [SerializeField] int _handCount;

    public List<CardState> Storage { get => _storage; set => _storage = value; }
    public int HandCount => _handCount;
}
