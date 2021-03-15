using UnityEngine;


namespace Stealth { 
    public class PawnController : MonoBehaviour
    {
        [SerializeField] private MovementStateMachine _movement;

        public void Move(Vector2 direction)
        {
            _movement.Move(direction);
        }
    }
}
