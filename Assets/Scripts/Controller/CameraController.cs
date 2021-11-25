using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        public float smoothMove = 0.125f;
        
        
        void LateUpdate()
        {
            Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothMove);
        }
    }
}