using System;
using UnityEngine;
using Utils.EventSystem;

namespace BrickBreaker.Scripts
{
    public class DeadZoneController : MonoBehaviour
    {
        [SerializeField] private GameEvent LevelFailed;
        private void OnCollisionEnter2D(Collision2D col)
        {
            col.collider.TryGetComponent(out BallController ball);
            if (ball)
            {
                LevelFailed.Raise();
            }
        }
    }
}