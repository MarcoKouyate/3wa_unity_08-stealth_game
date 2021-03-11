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
            _camera = Camera.main;
            _transform = transform;
        }
        private void FixedUpdate()
        {
            _direction.y = _height;
            _rigidbody.velocity = _direction * Time.fixedDeltaTime  * 100;
            
            if(_direction.x > 0 || _direction.z > 0)
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
            Vector3 lookRotation = _camera.transform.forward;
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
        private Camera _camera;
        private Transform _transform;
    }
}

