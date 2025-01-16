using UnityEngine;

public class SearchColliderByCircle : SearchCollider
{
    [SerializeField] private Vector3 _searchOffset;
    [SerializeField] private float _searchRadius;
    [SerializeField] private LayerMask _searchMask;

    private void Update()
    {
        Search();
    }
    private void Search()
    {
        if(Physics2D.OverlapCircle(transform.position + _searchOffset, _searchRadius, _searchMask))
        {
            AnimateStop();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + _searchOffset, _searchRadius);
    }
}
