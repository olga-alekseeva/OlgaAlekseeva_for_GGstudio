using System.Collections.Generic;

internal sealed class MoveSwitcher
{
    public EventHandler<Unit> OnUnitStartMove = new();

    private List<Unit> units = new List<Unit>();

    private int _unitIndex;

    public void OnUnitCreated(Unit unit)
    {
        units.Add(unit);
    }

    public void FirstRoundStarted()
    {
        _unitIndex = 0;
        CurrentUnitMove();
    }

    private void CurrentUnitMove()
    {
        Unit unit = units[_unitIndex];
        OnUnitStartMove.Handle(unit);
    }

    public void NextMove()
    {
        _unitIndex = (_unitIndex + 1) % units.Count;
        CurrentUnitMove();
    }
}
