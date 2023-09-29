using UnityEngine;

public class PlayerManager : GameManager
{
    FieldData _fieldData;
    int _totalCost = 0;
    int _currentTurn = 0;

    private void Start()
    {
        _fieldData = Set();
    }
    void Update()
    {
        if (NowTurn == TurnType.Player && _totalCost == _currentTurn)
        {
            BeginTurn();
        }
        CostText.text = _fieldData.PlayerCost.ToString();
    }
    public void BeginTurn()
    {
        Debug.Log("プレイヤーターン開始");
        _totalCost++;
        SetCost(Target.Player, _totalCost);
        int random = Random.Range(0, Storage.Storage.Count);
        var card = Instantiate((GameObject)Resources.Load("Character"), HandPosition);
        card.GetComponent<CardBase>().CardState = Storage.Storage[random];
        SetHand(Target.Player, card.GetComponent<CardBase>());
    }

    public void EndTurn()
    {
        Debug.Log("プレイヤーターン終了");
        _currentTurn = _totalCost;
        Instance.NowTurn = TurnType.Enemy;
    }
}
