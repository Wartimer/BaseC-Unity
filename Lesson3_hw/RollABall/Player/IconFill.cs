using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall.Player
{
    internal class IconFill : MonoBehaviour, IComparable
    {
        public int _id;
        private Image _image;
        private Text timer;

        private void Awake()
        {
            _image = GetComponent<Image>();
            timer = GetComponentInChildren<Text>();
            ClocksProcessor.Subscribe(this);
        }

        public void SetFillAmount(float fillAmt, float remTime)
        {
            timer.text = remTime.ToString("F1");
            _image.fillAmount = fillAmt;
        }

        public int CompareTo(object obj)
        {
            var c = (IconFill) obj;
            return _id.CompareTo(c._id);
        }
    }
}