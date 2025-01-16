using UnityEngine;

public interface IMoverValidator
{
    bool PickableFound(Vector3 searchPosition, out IPickableMove pickable, out SearchCollider searchCollider);
}
