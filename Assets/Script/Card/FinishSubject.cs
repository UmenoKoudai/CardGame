using System;
using UnityEngine;

public class FinishSubject : MonoBehaviour
{
    public Action OnFinished;

    private void OnDisable()
    {
        OnFinished?.Invoke();
    }
}
