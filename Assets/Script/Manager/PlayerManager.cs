using UnityEngine;

public class PlayerManager : GameManager
{
    int _totalCost = 0;
    int _currentTurn = 0;

    void Update()
    {
        CostText.text = _totalCost.ToString();
        if(NowTurn == TurnType.Player && _totalCost == _currentTurn)
        {
            BeginTurn();
        }
    }
    public void BeginTurn()
    {
        Debug.Log("�v���C���[�^�[���J�n");
        _totalCost++;
        int random = Random.Range(0, Storage.Storage.Count);
        var card = Instantiate((GameObject)Resources.Load("Character"), HandPosition);
        card.GetComponent<CardBase>().CardState = Storage.Storage[random];
        SetHand(Target.Player, card.GetComponent<CardBase>());
    }

    public void EndTurn()
    {
        Debug.Log("�v���C���[�^�[���I��");
        _currentTurn = _totalCost;
        Instance.NowTurn = TurnType.Enemy;
    }
}
