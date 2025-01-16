using UnityEngine;

public class Mover : IMover
{
    private IPickableMove _pickable; 
    private Vector3 _startDragPosition;

    public void StartDrag(IPickableMove pickable, Vector3 cursorPosition)
    {
        _pickable = pickable;
        _startDragPosition = _pickable.GetPosition() - cursorPosition;
        _pickable.StopFall();
    }
    public void Drag(Vector3 newPosition)
    {
        _pickable.MoveTo(_startDragPosition + newPosition);
    }
    public void StopDrag()
    {
        _pickable.StartFall();
    }
}
