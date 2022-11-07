using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.RefValues;
using Random = UnityEngine.Random;

namespace BrickBreaker.Scripts
{
    public class BrickController : MonoBehaviour
    {
        [SerializeField] private Material Blue;
        [SerializeField] private Material Red;
        [SerializeField] private Material Yellow;
        [SerializeField] private Material Green;
        [SerializeField] private SpriteRenderer Renderer;
        [SerializeField] private ParticleSystem BreakParticle;
        [SerializeField] private IntRef BrickCount;
        private ColorType _color;

        private void Start()
        {
            BrickCount.Value++;
            SetColor(GetRandomColor());
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            col.collider.TryGetComponent(out BallController ball);
            if (!ball)
                return;
            
            if (ball.GetColor() == _color)
            {
                if (BreakParticle)
                {
                    var particleObject = Instantiate(BreakParticle);
                    particleObject.transform.position = transform.position;
                }
                BrickCount.Value--;
                Destroy(gameObject);
            }
            else
            {
                SetColor(ball.GetColor());
            }

        }

        private ColorType GetRandomColor()
        {
            return (ColorType)Random.Range(0, Enum.GetNames(typeof(ColorType)).Length);
        }

        private void SetColor(ColorType _type)
        {
            _color = _type;
            switch (_type)
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