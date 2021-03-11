using UnityEngine;

namespace Stealth { 
    public class PlugInputToPlayer : MonoBehaviour
    {
        [SerializeField] private PawnController _pawn;

        void Update()
        {
            _pawn.Move(InputController.Instance.MovementInput);
        }
    }
}
