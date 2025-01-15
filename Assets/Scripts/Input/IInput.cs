using UnityEngine;

public interface IInput
{
    Vector3 CursorScreenPosition();
    Vector3 CursorWorldPosition();
    bool CursorDown();
    bool CursorHold();
    bool CursorUp();
    bool IsMoving();

}
