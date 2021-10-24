namespace RollABall.Player
{
    public interface IInteractable : IAction, IInitialization
    {
        bool IsInteractable { get; }
    }
}