using UnityEngine;
using Random = UnityEngine.Random;

namespace Spinner.Scripts
{
    public class SpinWheelController : MonoBehaviour
    {
        [SerializeField] private Vector2 SpeedMinMax;
        [SerializeField] private Vector2 DecSpeedMinMax;
    
        private float _speed;
        private float _decSpeed;
        private bool _isSpinning;

        private void Update()
        {
            if (_isSpinning)
            {
                transform.Rotate(0,0,_speed);
                _speed -= _decSpeed;
            }
            if (_speed <= 0)
            {
                _speed = 0;
                _isSpinning = false;
            }
        }

        public void Spin()
        {
            _speed = Random.Range(SpeedMinMax.x, SpeedMinMax.y);
            _decSpeed = Random.Range(DecSpeedMinMax.x, DecSpeedMinMax.y);
            _isSpinning = true;
        }
    }
}
