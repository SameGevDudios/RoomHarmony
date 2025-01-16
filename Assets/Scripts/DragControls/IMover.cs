using UnityEngine;

public interface IMover
{
    void StartDrag(IMovable movable, Vector3 cursorPosition);
    void Drag(Vector3 cursorPosition);
    void StopDrag();
}
