using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform _target; // The target object to follow
    Vector3 _offset = new Vector3(0f, 0f, -10f); // Offset from the target object
    float _smoothSpeed = 10f; // How smoothly the camera catches up to its target
    float yOffset = 0f;
    float targetAspect = 9f / 16f;
    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(_target.position.x +5f, transform.position.y + yOffset, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
    }
}
