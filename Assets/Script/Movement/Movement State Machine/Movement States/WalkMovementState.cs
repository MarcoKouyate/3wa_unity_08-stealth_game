using UnityEngine;
using MemoTools;

namespace Stealth {
    [CreateAssetMenu(fileName = "Movement State", menuName = "State Machine/Movement/Walk")]
    public class WalkMovementState : MovementState
    {
        [SerializeField] private float _movementThreshold;
        [SerializeField] private MovementState _idleState;

        public override void Move(Vector2 direction) {
            Machine.Movement.Move(direction);

            if (!Utilities.IsVectorActive(direction, _movementThreshold))
            {
                Machine.SwitchTo(_idleState);
            }
        }
    }
}
