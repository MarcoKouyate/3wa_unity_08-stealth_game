using UnityEngine;
using MemoTools;


namespace Stealth {
    [CreateAssetMenu(fileName = "Movement State", menuName = "State Machine/Movement/Idle")]
    public class IdleMovementState : MovementState
    {
        [SerializeField] private float _movementThreshold;
        [SerializeField] private MovementState _walkState;

        public override void Move(Vector2 direction) {
            if (Utilities.IsVectorActive(direction, _movementThreshold))
            {
                Machine.SwitchTo(_walkState);
            }
        }
    }
}
