using UnityEngine;

public class MobileInput : IInput
{
    private Vector2 _deltaPosition;
    private Vector2 _lastTouchPosition;
    private bool _isTouchMoving;

    public Vector3 CursorScreenPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        return Vector3.zero;
    }
    public Vector3 CursorWorldPosition()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            return new Vector3(touchPosition.x, touchPosition.y, 0);
        }
        return Vector3.zero;
    }
    public bool CursorDown() =>
        Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    public bool CursorHold() => 
        Input.touchCount > 0 &&
        (Input.GetTouch(0).phase == TouchPhase.Moved ||
        Input.GetTouch(0).phase == TouchPhase.Stationary);
    public bool CursorUp() =>
        Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    public bool IsMoving()
    {
        UpdateDelta();
        return CursorHold() && _isTouchMoving;
    }
    private void UpdateDelta()
    {
        if (Input.touchCount > 0)
        {
            Vector2 currentTouchPosition = CursorScreenPosition();
            _deltaPosition = currentTouchPosition - _lastTouchPosition;
            _lastTouchPosition = currentTouchPosition;
            _isTouchMoving = _deltaPosition.sqrMagnitude > 0;
        }
        else
        {
            _deltaPosition = Vector2.zero;
            _isTouchMoving = false;
        }
    }
}
