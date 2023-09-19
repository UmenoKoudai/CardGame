using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn
{
    NowTurn _nowTurn = NowTurn.Player;
    public NowTurn GetTurn { get => _nowTurn; set => _nowTurn = value; }
}

public enum NowTurn
{
    Player,
    Enemy,
}