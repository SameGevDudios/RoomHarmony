using UnityEngine;

public class DesktopInput : IInput
{
    private Vector2 _deltaPosition;
    private Vector2 _lastMousePosition;
    private bool _isMouseMoving;

    public Vector3 CursorScreenPosition() => 
        Input.mousePosition;
    public Vector3 CursorWorldPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(mousePosition.x, mousePosition.y, 0);
    }
    public bool CursorDown() => Input.GetMouseButtonDown(0);
    public bool CursorHold() => Input.GetMouseButton(0);
    public bool CursorUp() => Input.GetMouseButtonUp(0);
    public bool IsMoving()
    {
        UpdateDelta();
        return CursorHold() && _isMouseMoving;
    }
    private void UpdateDelta()
    {
        Vector2 currentMousePosition = CursorScreenPosition();
        _deltaPosition = currentMousePosition - _lastMousePosition;
        _lastMousePosition = currentMousePosition;
        _isMouseMoving = _deltaPosition.sqrMagnitude > 0;
    }
}
