using UnityEngine;
using MemoTools;

namespace Stealth { 

    public abstract class MovementState : ScriptableState<MovementState>
    {
        public abstract void Move(Vector2 direction);
    }
}
