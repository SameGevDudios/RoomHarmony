using UnityEngine;

public interface IMover
{
    void StartDrag(IPickableMove pickable, Vector3 cursorPosition);
    void Drag(Vector3 cursorPosition);
    void StopDrag();
}
