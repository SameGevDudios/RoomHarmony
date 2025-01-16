using UnityEngine;

public class Mover : IMover
{
    private IMovable _movable; 
    private Vector3 _startDragPosition;

    public void StartDrag(IMovable movable, Vector3 cursorPosition)
    {
        _movable = movable;
        _startDragPosition = _movable.GetPosition() - cursorPosition;
        _movable.StopFall();
    }
    public void Drag(Vector3 newPosition)
    {
        _movable.MoveTo(_startDragPosition + newPosition);
    }
    public void StopDrag()
    {
        _movable.StartFall();
    }
}
