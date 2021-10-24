using UnityEngine;

namespace RollABall.Player
{
    internal sealed class PlayerBall : Player
    {
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            PlayerMatController.SetMaterial(GetComponent<Renderer>().material);
        }
        
        public override void Move(float x, float y, float z)
        {
            if(_rigidbody)
                _rigidbody.AddForce(new Vector3(x,y,z) * _speed);
        }
    }
}