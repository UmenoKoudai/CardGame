using UnityEngine;

public class EnemyManager : GameManager
{
    int _totalCost = 0;
    int _currentTurn = 0;
    void Update()
    {
        CostText.text = EnemyCost.ToString();
        if(NowTurn == TurnType.Enemy && _currentTurn == _totalCost)
        {
            BeginTurn();
        }
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
