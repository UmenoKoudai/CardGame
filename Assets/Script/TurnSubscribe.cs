using UnityEngine;

public class TurnSubscribe : MonoBehaviour
{
    private void OnEnable()
    {
        TurnManager._onBeginTurn += OnBeginTurn;
        TurnManager._onEndTurn += OnEndTurn;
    }

    private void OnDisable()
    {
        TurnManager._onBeginTurn -= OnBeginTurn;
        TurnManager._onEndTurn -= OnEndTurn;
    }
    public virtual void OnBeginTurn()
    {
        Debug.LogError("ターン開始時の処理がオーバーライドされていません");
    }
    public virtual void OnEndTurn()
    {
        Debug.LogError("ターン終了時の処理がオーバーライドされていません");
    }
}
