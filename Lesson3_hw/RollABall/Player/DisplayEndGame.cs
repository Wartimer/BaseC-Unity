using System;
using UnityEngine.UI;

namespace RollABall.Player
{
    internal sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        internal DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = string.Empty;
        }

        internal void GameOver(object o)
        {
            if (o == null) throw new NullReferenceException();
            _finishGameLabel.text = "Вы Проиграли";
        }

        internal void Win(int points)
        {
            _finishGameLabel.text = $"ПОБЕДА / {points}";
        }
    }
}