using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CatHead : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private int maxRotationAngle;
    [SerializeField] private float rotationSensitivity;

    private void Update()
    {
        Vector2 mousePan = gameInput.GetMousePan();
        rotateUpOrDown(mousePan);
    }

    private void rotateUpOrDown(Vector2 mousePan)
    {
        // TODO: should probably put some bounds on this...
        float panWithinBounds = convertPanWithinBounds(-mousePan.y * rotationSensitivity);
        transform.Rotate(Vector3.right, panWithinBounds, Space.Self);
    }

    private float convertPanWithinBounds(float pan)
    {
        float currentRotationX = transform.rotation.eulerAngles.x;
        if (currentRotationX > 180)
        {
            currentRotationX -= 360;
        }
        
        if (pan > 0)
        {
            float panToMax = maxRotationAngle - currentRotationX;
            return Mathf.Min(pan, panToMax);
        }

        if (pan < 0)
        {
            float panToMin = -maxRotationAngle - currentRotationX;
            return Mathf.Max(pan, panToMin);
        }
        
        // pan must be 0 so return pan
        return pan;
    }
}