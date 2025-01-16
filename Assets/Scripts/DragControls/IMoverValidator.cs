using UnityEngine;

public interface IMoverValidator
{
    bool MovableFound(Vector3 searchPosition, out IMovable movable, out SearchCollider searchCollider);
}
