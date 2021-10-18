using UnityEngine;
using static UnityEngine.Debug;

namespace RollABall.Player
{
    internal sealed class ReduceSpeed : BadBonus, IFlay, IRotation, IHaveDuration
    {
        [SerializeField] private int _id = 1;
        [SerializeField] private float decreaseAmt = 0.2f;
        [SerializeField] private float _duration = 3.0f;
        private float _lengthFlay;
        private float _speedRotation;
        public int Id => _id;
        public float Duration => _duration;
        
       
        private void Awake()
        {
            
            _lengthFlay = Random.Range(0.1f, 0.3f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }
        
        protected override void Interaction()
        {
            //Reduce speed
            base.Interaction();
            _player._speed -= decreaseAmt;
            Log($"Speed decreased for {decreaseAmt}");
            BonusProcessor.AddDuration(this);
            ClocksProcessor.ActivateClock(Id);
        }
        
        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

    }
}