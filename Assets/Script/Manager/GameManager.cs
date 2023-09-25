using UnityEngine;
using UnityEngine.UI;

public class GameManager : FieldData
{
    [SerializeField] Text _costText;
    [SerializeField] Transform _hand;
    [SerializeField] CardStorage _storage;
    static GameManager _instance;
    public static GameManager Instance => _instance;
    TurnType _nowTurn;

    public TurnType NowTurn { get => _nowTurn; set => _nowTurn = value; }
    public Transform HandPosition => _hand;
    public CardStorage Storage => _storage;
    public Text CostText { get => _costText; set => _costText = value; }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public enum TurnType
    {
        Player,
        Enemy,
    }
}
