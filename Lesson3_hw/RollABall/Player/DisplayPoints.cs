using TMPro;
using UnityEngine;

namespace RollABall.Player
{
    public sealed class DisplayPoints
    {
        private TextMeshProUGUI _text;

        public DisplayPoints()
        {
            _text = Object.FindObjectOfType<TextMeshProUGUI>();
        }

        public void Display(int value)
        {
            _text.text = $"Score: {value}/100";
        }
    }
}