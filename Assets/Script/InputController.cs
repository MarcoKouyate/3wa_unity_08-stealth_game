
using UnityEngine;


namespace Stealth { 
    public class InputController : MonoBehaviour
    {
        [SerializeField] private PawnController _pawn;

        void Awake()
        {
            
        }

        void Update()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            float magnitude = Mathf.Clamp01(input.magnitude);
            input.Normalize();
            _pawn.Move(input * magnitude);
        }
    }
}
