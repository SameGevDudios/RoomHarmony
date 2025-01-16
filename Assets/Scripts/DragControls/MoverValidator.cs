using UnityEngine;

public class MoverValidator : IMoverValidator
{
    public bool PickableFound(Vector3 searchPosition, out IPickableMove pickable, out SearchCollider searchCollider)
    {
        pickable = null;
        searchCollider = null;
        RaycastHit2D hit = Physics2D.Raycast(searchPosition, Vector3.forward, int.MaxValue);
        if (hit)
        {
            pickable = hit.collider.gameObject.GetComponent<IPickableMove>();
            searchCollider = hit.collider.gameObject.GetComponent<SearchCollider>();
        }
        return pickable != null && searchCollider != null;
    }
}
