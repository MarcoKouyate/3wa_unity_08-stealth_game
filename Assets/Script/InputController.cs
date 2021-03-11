
using UnityEngine;
using MemoTools;


namespace Stealth { 
    public class InputController : SingletonMonoBehaviour<InputController>
    {
        [SerializeField] private float _axisThreshold;
 
        protected override bool DestroyOnLoad { get => true; }

        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }
        public Vector2 MovementInput { get; private set; }
        public bool HasMovement { get; private set; }

        protected override void InitAwake()
        {
            
        }

        void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
            MovementInput = CreateMovementInput(HorizontalInput, VerticalInput);
            HasMovement = IsAxisActive(HorizontalInput) || IsAxisActive(VerticalInput);
        }

        private Vector2 CreateMovementInput(float horizontal, float vertical)
        {
            Vector2 input = new Vector2(horizontal, vertical);
            return Vector2.ClampMagnitude(input, 1);
        }

        public bool IsAxisActive(string axisName)
        {
            return IsAxisActive(Input.GetAxisRaw(axisName));
        }

        private bool IsAxisActive(float amount)
        {
            return Mathf.Abs(amount) > _axisThreshold;
        }
    }
}
