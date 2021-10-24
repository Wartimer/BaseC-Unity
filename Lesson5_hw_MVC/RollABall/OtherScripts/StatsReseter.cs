using UnityEngine;

namespace RollABall.Player
{
    internal static class StatsReseter
    {
        public static void ResetStats(Player player, int id)
        {
            switch (id)
            {
                case 0:
                    player._speed = player._startSpeed;
                    Debug.Log("Speed RETURNED");
                    break;
                case 1:
                    player._speed = player._startSpeed;
                    Debug.Log("Speed RETURNED");
                    break;
                case 2:
                    player.Invulnerable = !player.Invulnerable;
                    player.GetComponent<Renderer>().material = PlayerMatController.ReturnMaterial();
                    Debug.Log("VULNERABLE");
                    break;
            }
        }
    }
}