using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Card")]
public class CardStorage : ScriptableObject
{
    [SerializeField] CardState[] _storage;
    [SerializeField] int _handCount;

    public CardState[] Storage => _storage;
    public int HandCount => _handCount;
}
