using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGenerator : FieldData
{
    [SerializeField] CardStorage _storage;
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        for(int i = 0; i < _storage.HandCount; i++)
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
