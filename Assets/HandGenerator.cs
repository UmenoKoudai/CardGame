using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGenerator : FieldData
{
    [SerializeField] CardStorage _storage;
    [SerializeField] int _handCount;
    void Start()
    {
        for(int i = 0; i < _handCount; i++)
        {
            int random = Random.Range(0, _storage.Storage.Count);
            SetHand(Target.Player, _storage.Storage[random]);
            random = Random.Range(0, _storage.Storage.Count);
            SetHand(Target.Enemy, _storage.Storage[random]);
        }
    }

    void Update()
    {
        
    }
}
