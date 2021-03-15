using UnityEngine;
using MemoTools;

namespace Stealth { 
    public class MovementStateMachine : StateMachine<MovementState, MovementStateMachine>
    {
        public Movement Movement;

        public void Move(Vector2 direction)
        {
            CurrentState.Move(direction);
        }
    }
}
