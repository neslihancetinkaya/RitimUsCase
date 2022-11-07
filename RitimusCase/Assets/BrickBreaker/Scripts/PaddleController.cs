using UnityEngine;

namespace BrickBreaker.Scripts
{
    public class PaddleController : MonoBehaviour
    {
        [SerializeField] private float SwerveSpeed;
        [SerializeField] private float MaxSwerveAmount;
        
        private float _lastXPos;
        private float _moveFactorX;
       

        private void Update()
        {
            HandleInput();
            Swerve();
            
            #if UNITY_EDITOR
                KeyboardMovement();
            #endif
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastXPos = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastXPos;
                _lastXPos = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
        }

        private void Swerve()
        {
            float swerveAmount = Time.deltaTime * SwerveSpeed * _moveFactorX;
            float finalPos = transform.position.x + swerveAmount;
            
            if (finalPos < -MaxSwerveAmount)
                swerveAmount = -MaxSwerveAmount - transform.localPosition.x;
            else if(finalPos > MaxSwerveAmount)
                swerveAmount = MaxSwerveAmount - transform.localPosition.x;
            
            transform.position += transform.right * swerveAmount;
        }

        private void KeyboardMovement()
        {
            float swerveAmount = 0;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                swerveAmount = Time.deltaTime * SwerveSpeed;
                float finalPos = transform.position.x + swerveAmount;
            
                if (finalPos < -MaxSwerveAmount)
                    swerveAmount = -MaxSwerveAmount - transform.localPosition.x;
                
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                swerveAmount = -Time.deltaTime * SwerveSpeed;
                float finalPos = transform.position.x + swerveAmount;
            
                if(finalPos > MaxSwerveAmount)
                    swerveAmount = MaxSwerveAmount - transform.localPosition.x;
            
            }
            transform.position += transform.right * swerveAmount;
        }
    }
}
