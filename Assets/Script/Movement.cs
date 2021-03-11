using UnityEngine;

namespace Stealth
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

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
            
            if(InputController.Instance.IsAxisActive(_direction.x) || InputController.Instance.IsAxisActive(_direction.z))
            {
                LookTowardsCamera();
            }
        }

        public void Move(Vector2 direction)
        {
            Vector3 localDirection = new Vector3(direction.x, 0, direction.y);
            _direction = _transform.TransformDirection(localDirection) * _movementSpeed;
        }

        public void Rise(float height)
        {
            _height = height;
        }


        private void LookTowardsCamera()
        {
            Vector3 lookRotation = _cameraTransform.forward;
            lookRotation.y = 0;
            LookTowards(lookRotation);
        }

        private void LookTowards(Vector3 lookRotation)
        {
            Quaternion rotation = Quaternion.LookRotation(lookRotation);
            rotation = Quaternion.RotateTowards(_rigidbody.rotation, rotation, _rotationSpeed * Time.fixedDeltaTime * 100);
            _rigidbody.MoveRotation(rotation);
        }

        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private float _height;
        private Transform _transform;
        private Transform _cameraTransform;
    }
}

