using UnityEngine;

public class SearchColliderByCircle : SearchCollider
{
    [SerializeField] private Vector3 _searchOffset;
    [SerializeField] private float _searchRadius;
    [SerializeField] private LayerMask _searchMask;
    private IPickableScale _pickableScale;

    protected override void Start()
    {
        base.Start();
        _pickableScale = _pickableObject.GetComponentInParent<IPickableScale>();
        if (_pickableScale == null)
            Debug.LogError($"IPickableScale couldn't be found on {_pickableObject.name} GameObject");
    }
    private void Update()
    {
        if(_canSearch)
            Search();
    }
    private void Search()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position + _searchOffset, _searchRadius, _searchMask);
        if (col)
        {
            // Animation
            AnimateStop();
            // Scale
            Transform colParent = col.transform.parent;
            IPickableCollider collider = colParent.GetComponentInParent<IPickableCollider>();
            if (collider != null)
            {
                float distance = Mathf.Abs(transform.position.y - colParent.position.y);
                float scale = collider.ScaleByDistance(distance);
                _pickableScale.SetNewScale(scale);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + _searchOffset, _searchRadius);
    }
}
