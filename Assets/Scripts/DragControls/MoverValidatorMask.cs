using UnityEngine;

public class MoverValidatorMask : IMoverValidator
{
    private LayerMask _serachMask;
    public MoverValidatorMask(LayerMask searchMask)
    {
        _serachMask = searchMask;
    }
    public bool PickableFound(Vector3 searchPosition, out IPickableMove pickable, out SearchCollider searchCollider)
    {
        pickable = null;
        searchCollider = null;
        RaycastHit2D hit = Physics2D.Raycast(searchPosition, Vector3.forward, int.MaxValue, _serachMask);
        if (hit)
        {
            pickable = hit.collider.gameObject.GetComponent<IPickableMove>();
            searchCollider = hit.collider.gameObject.GetComponent<SearchCollider>();
        }
        return pickable != null && searchCollider != null;
    }
}
