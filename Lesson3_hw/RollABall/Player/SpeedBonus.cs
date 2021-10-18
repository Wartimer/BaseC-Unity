using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using static UnityEngine.Debug;

namespace RollABall.Player
{
    internal sealed class SpeedBonus : GoodBonus, IFlay, IFlicker, IHaveDuration
    {
        [SerializeField] private int _id = 0;
        [SerializeField] private float _increaseAmt = 4.5f;
        [SerializeField] private float _duration = 3.0f;
        private float _lengthFlay;
        private Material _material;

        public int Id => _id;
        public float Duration => _duration;


        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(0.1f, 0.3f);
        }

        protected override void Interaction()
        {
            base.Interaction();
            _player._speed += _increaseAmt;
            Log($"Speed increased for {_increaseAmt}");
            BonusProcessor.AddDuration(this);
            ClocksProcessor.ActivateClock(Id);
        }
        
        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                                                Mathf.PingPong(Time.time, _lengthFlay),
                                                  transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 
                                                            Mathf.PingPong(Time.time, 1.0f));
        }


    }
}