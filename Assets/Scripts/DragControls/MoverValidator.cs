using UnityEngine;

public class MoverValidator : IMoverValidator
{
    public bool MovableFound(Vector3 searchPosition, out IMovable movable, out SearchCollider searchCollider)
    {
        movable = null;
        searchCollider = null;
        RaycastHit2D hit = Physics2D.Raycast(searchPosition, Vector3.forward, int.MaxValue);
        if (hit)
        {
            movable = hit.collider.gameObject.GetComponent<IMovable>();
            searchCollider = hit.collider.gameObject.GetComponent<SearchCollider>();
        }
        return movable != null && searchCollider != null;
    }
}
