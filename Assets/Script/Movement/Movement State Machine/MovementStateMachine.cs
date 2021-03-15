using UnityEngine;
using MemoTools;

namespace Stealth { 
    public class MovementStateMachine : StateMachine<MovementState>
    {
        public void Move(Vector2 direction)
        {
            CurrentState.Move(direction);
        }
    }
}
