using System;
using TMPro;
using UnityEngine;

namespace RollABall.Player
{
    public sealed class DisplayPoints
    {
        private TextMeshProUGUI _scoreText;

        public DisplayPoints(GameObject scoreText)
        {
            _scoreText = scoreText.GetComponent<TextMeshProUGUI>();
            _scoreText.text = String.Empty;
        }

        public void Display(int value)
        {
            _scoreText.text = $"Score: {value}/100";
        }
    }
}