using UnityEngine;


namespace Stealth { 
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        #region Idle
        public void StartIdle()
        {
            _animator.SetBool(IdleId, true);
        }

        public void StopIdle()
        {
            _animator.SetBool(IdleId, false);
        }
        #endregion


        #region Jogging
        public void StartJogging()
        {
            _animator.SetBool(JoggingId, true);
        }

        public void StopJogging()
        {
            _animator.SetBool(JoggingId, false);
        }
        #endregion


        #region Falling
        public void StartFalling()
        {
            _animator.SetBool(FallingId, true);
        }

        public void StopFalling()
        {
            _animator.SetBool(FallingId, false);
        }
        #endregion


        #region Jumping
        public void StartJumping()
        {
            _animator.SetBool(JumpingId, true);
        }

        public void StopJumping()
        {
            _animator.SetBool(JumpingId, false);
        }
        #endregion


        #region IsGrounded
        public void SetGrounded(bool active)
        {
            _animator.SetBool(IsGroundedId, active);
        }
        #endregion

        public void SetMovement(Vector2 direction)
        {
            _animator.SetFloat(HorizontalMovementId, direction.x);
            _animator.SetFloat(VerticalMovementId, direction.y);
        }

        private int IdleId = Animator.StringToHash("Idle");
        private int JoggingId = Animator.StringToHash("Jogging");
        private int FallingId = Animator.StringToHash("Falling");
        private int JumpingId = Animator.StringToHash("Jumping");
        private int IsGroundedId = Animator.StringToHash("IsGrounded");
        private int HorizontalMovementId = Animator.StringToHash("MovementX");
        private int VerticalMovementId = Animator.StringToHash("MovementY");
    }
}
