using UnityEngine;

public class PlayerManager : GameManager
{
    int _totalCost = 1;
    int _
    void Start()
    {
        
    }

    void Update()
    {
        CostText.text = _totalCost.ToString();
    }

    public void EndTurn()
    {
        TurnManager.EndTurn();
    }

    public override void OnBeginTurn()
    {
        _totalCost++;
        int random = Random.Range(0, Storage.Storage.Length);
        var card = Instantiate((GameObject)Resources.Load("Character"), HandPosition);
        card.GetComponent<CardBase>().CardState = Storage.Storage[random];
        SetHand(Target.Player, card.GetComponent<CardBase>());
    }

    public override void OnEndTurn()
    {
        NowTurn = TurnType.Enemy;
    }
}
