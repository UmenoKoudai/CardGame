using System;

public class TurnManager
{
    public static Action _onBeginTurn;
    public static Action _onEndTurn;

    public static void BeginTurn()
    {
        _onBeginTurn();
    }

    public static void EndTurn()
    {
        _onEndTurn();
    }
}
