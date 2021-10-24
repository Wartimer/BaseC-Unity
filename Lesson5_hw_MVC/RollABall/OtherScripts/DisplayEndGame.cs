using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall.Player
{
    internal sealed class DisplayEndGame: IDisposable
    {
        private Text _finishGameLabel;

        internal DisplayEndGame(GameObject endGameLabel)
        {
            _finishGameLabel = endGameLabel.GetComponent<Text>();
            _finishGameLabel.text = String.Empty;
        }

        internal void GameOver(object o, Player player)
        {
            if (o == null) throw new NullReferenceException();
            _finishGameLabel.text = $"{player.name} Вы Проиграли";
        }

        internal void Win(int points)
        {
            _finishGameLabel.text = $"ПОБЕДА / {points}";
        }

        public void Dispose()
        {
            _finishGameLabel = null;
        }
    }
}