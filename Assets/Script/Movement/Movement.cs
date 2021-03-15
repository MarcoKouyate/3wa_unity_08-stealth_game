using UnityEngine;

namespace Stealth
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        #region Show In Region
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        #endregion


        #region Unity Cycle
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _cameraTransform = Camera.main.transform;
            _transform = transform;
        }

        private void FixedUpdate()
        {
            _direction.y = _height;
            _rigidbody.velocity = _direction * Time.fixedDeltaTime  * 100;
            
            if(HasMovement())
            {
                LookTowardsCamera();
            }
        }
        #endregion


        #region Public Methods
        public void Move(Vector2 direction)
        {
            Vector3 localDirection = new Vector3(direction.x, 0, direction.y);
            _direction = _transform.TransformDirection(localDirection) * _movementSpeed;
        }

        public void Rise(float height)
        {
            _height = height;
        }
        #endregion


        #region Private Methods
        private bool HasMovement()
        {
            return InputController.Instance.IsAxisActive(_direction.x) || InputController.Instance.IsAxisActive(_direction.z);
        }

        private void LookTowardsCamera()
        {
            Vector3 lookRotationToCamera = _cameraTransform.forward;
            lookRotationToCamera.y = 0;
            LookTowards(lookRotationToCamera);
        }

        private void LookTowards(Vector3 lookRotation)
        {
            Quaternion rotation = Quaternion.LookRotation(lookRotation);
            rotation = Quaternion.RotateTowards(_rigidbody.rotation, rotation, _rotationSpeed * Time.fixedDeltaTime * 100);
            _rigidbody.MoveRotation(rotation);
        }
        #endregion

        #region Private Variables
        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private float _height;
        private Transform _transform;
        private Transform _cameraTransform;
        #endregion
    }
}

