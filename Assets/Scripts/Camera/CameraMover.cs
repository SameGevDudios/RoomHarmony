using UnityEngine;

public class CameraMover : ICameraMover
{
    private Transform _cameraTransform;
    private float _dragSpeed, _minPosition, _maxPosition, _startPosition;

    public CameraMover(Transform cameraTransform, float dragSpeed, float minPosition, float maxPosition)
    {
        _cameraTransform = cameraTransform;
        _dragSpeed = dragSpeed;
        _minPosition = minPosition;
        _maxPosition = maxPosition;
    }
    public void StartDrag(float startPosition)
    {
        _startPosition = startPosition;
    }
    public void Drag(float currentPosition)
    {
        float dragDelta = _startPosition - currentPosition;
        float newPosition = _cameraTransform.position.x + dragDelta * _dragSpeed * Time.deltaTime;
        newPosition = Mathf.Clamp(newPosition, _minPosition, _maxPosition);
        _cameraTransform.position = Vector3.right * newPosition;
        StartDrag(currentPosition);
    }

}
