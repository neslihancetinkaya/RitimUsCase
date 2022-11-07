using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BrickBreaker.Scripts
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Material Blue;
        [SerializeField] private Material Red;
        [SerializeField] private Material Yellow;
        [SerializeField] private Material Green;
        [SerializeField] private float Speed;
        [SerializeField] private Vector2 FallRange;
        [SerializeField] private SpriteRenderer Renderer;

        private Rigidbody2D _rb { get; set; }
        private ColorType _color;
        private float _yFall = -1f;
        private float _invokeDuration = 1f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            SetColor();
        }

        private void Start()
        {
            Invoke(nameof(SetRandomDirection), _invokeDuration);
        }

        private void SetRandomDirection()
        {
            Vector2 force = Vector2.zero;
            force.x = Random.Range(FallRange.x, FallRange.y);
            force.y = _yFall;
            
            _rb.AddForce(force.normalized * Speed);
        }

        public ColorType GetColor()
        {
            return _color;
        }
        
        private void SetColor()
        {
            _color = (ColorType)Random.Range(0, Enum.GetNames(typeof(ColorType)).Length);
            switch (_color)
            {
                case ColorType.Blue:
                    Renderer.material = Blue;
                    break;
                case ColorType.Red:
                    Renderer.material = Red;
                    break;
                case ColorType.Yellow:
                    Renderer.material = Yellow;
                    break;
                case ColorType.Green:
                    Renderer.material = Green;
                    break;
            }
        }
    }
}
