using UnityEngine;
using UnityEngine.UI;

public class GameManager : FieldData
{
    [SerializeField] Text _costText;
    [SerializeField] Transform _hand;
    [SerializeField] CardStorage _storage;
    TurnType _nowTurn;

    public TurnType NowTurn { get => _nowTurn; set => _nowTurn = value; }
    public Transform HandPosition => _hand;
    public CardStorage Storage => _storage;
    public Text CostText { get => _costText; set => _costText = value; }

    public enum TurnType
    {
        Player,
        Enemy,
    }

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
