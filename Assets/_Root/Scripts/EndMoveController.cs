internal sealed class EndMoveController
{
    public EventHandler OnEndCurrentMove = new();

    public void EndCurrentMove()
    {
        OnEndCurrentMove.Handle();
    }
}
