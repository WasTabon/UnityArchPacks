using UnityEngine;

namespace UnityArchPacks.MatrixTransformation.Scripts
{
    public class MatrixMovement : MonoBehaviour
    {
        [Header("YOU HAVE TO CLICK ON OBJECT TO MOVE IT")]
        
        [SerializeField] private Vector3 _translation = new Vector3(3, 0, 0);
        [SerializeField] private Quaternion _rotation = Quaternion.Euler(0, 90, 0);
        [SerializeField] private Vector3 _scale = new Vector3(2, 2, 2);
        
        [Header("Matrix translation Example")]
        [SerializeField] private Matrix4x4 _tempTranslation = Matrix4x4.Translate(new Vector3(3, 0, 0));
        [SerializeField] private Matrix4x4 _tempRotation = Matrix4x4.Rotate(Quaternion.Euler(0, 90, 0));
        [SerializeField] private Matrix4x4 _tempScaling = Matrix4x4.Scale(new Vector3(2, 2, 2));
        
        private void ApplyMatrix()
        {
            Matrix4x4 translation = Matrix4x4.Translate(_translation);
            
            Matrix4x4 rotation = Matrix4x4.Rotate(_rotation);
            
            Matrix4x4 scaling = Matrix4x4.Scale(_scale);
            
            Matrix4x4 transformation = translation * rotation * scaling;
            
            transform.position = transformation.MultiplyPoint3x4(transform.position);
            transform.rotation = rotation.rotation;
            transform.localScale = scaling.lossyScale;
            
            // Or like this
            // Matrix4x4 matrix = Matrix4x4.TRS(translation, rotation, scale);
            //
        }
        
        private void OnMouseDown()
        {
            ApplyMatrix();
        }
    }
}
