using UnityEngine;

namespace UnityArchPacks.CylindricalCoordinateSystem.Scripts
{
    public class CircularMovement : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        
        [SerializeField] private float _radius = 5f;
        [SerializeField] private float _angularSpeed = 2f;
        [SerializeField] private float _heightOffset = 0f;

        private float _angle = 0f;

        private void Update()
        {
            if (_playerTransform == null) return;
            
            MoveAroundObject(_playerTransform);
        }

        private void MoveAroundObject(Transform target)
        {
            _angle += _angularSpeed * Time.deltaTime;

            float x = target.position.x + _radius * Mathf.Cos(_angle);
            float z = target.position.z + _radius * Mathf.Sin(_angle);
            float y = target.position.y + _heightOffset;

            transform.position = new Vector3(x, y, z);
        }
    }
}