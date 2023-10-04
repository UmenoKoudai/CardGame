using UnityEngine;

public class EnemyManager : GameManager
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
        if(NowTurn == TurnType.Enemy && _currentTurn == _totalCost)
        {
            BeginTurn();
        }
        CostText.text = _fieldData.EnemyCost.ToString();
    }

    public void BeginTurn()
    {
        Debug.Log("エネミーターン開始");
        _totalCost++;
        SetCost(Target.Enemy, _totalCost);
        int random = Random.Range(0, Storage.Storage.Count);
        var card = Instantiate((GameObject)Resources.Load("Character"), HandPosition);
        card.GetComponent<CardBase>().CardState = Storage.Storage[random];
        SetHand(Target.Enemy, card.GetComponent<CardBase>());
        EndTurn();
    }

    public void EndTurn()
    {
        Debug.Log("エネミーターン終了");
        _currentTurn = _totalCost;
        Instance.NowTurn = TurnType.Player;
    }
}
