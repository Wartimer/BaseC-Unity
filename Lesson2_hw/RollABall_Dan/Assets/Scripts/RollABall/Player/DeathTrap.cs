namespace RollABall.Player
{
    public sealed class DeathTrap : InteractiveObject
    {
        protected override void Interaction()
        {
            _player.Dispose();
        }
    }
}