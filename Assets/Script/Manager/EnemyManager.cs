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
        Debug.Log("�G�l�~�[�^�[���J�n");
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
        Debug.Log("�G�l�~�[�^�[���I��");
        _currentTurn = _totalCost;
        Instance.NowTurn = TurnType.Player;
    }
}
