using UnityEngine;

namespace Stealth
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }
        private void FixedUpdate()
        {
            _direction.y = _height;
            _rigidbody.velocity = _direction * Time.fixedDeltaTime  * 100;
        }

        public void Move(Vector2 direction)
        {
            Vector3 localDirection = new Vector3(direction.x, 0, direction.y);
            _direction = _camera.transform.TransformDirection(localDirection) * _speed;
        }

        public void Rise(float height)
        {
            _height = height;
        }


        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private float _height;
        private Camera _camera;
    }
}

