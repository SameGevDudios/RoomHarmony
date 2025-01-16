using UnityEngine;

public abstract class SearchCollider : MonoBehaviour
{
    [SerializeField] private GameObject _pickableObject;
    private IPickableMove _pickable;
    private bool _canSearch = true;
    private void Start()
    {
        _pickable = _pickableObject.GetComponent<IPickableMove>();
        if (_pickable == null)
            Debug.LogError($"IPickableMove couldn't be found on {_pickableObject.name} GameObject");
    }
    protected void AnimateStop()
    {
        if (_canSearch)
        {
            _pickable.AnimateStop();
            _canSearch = false;
        }
    }
    public void AllowSearch(bool allow)
    {
        _canSearch = allow;
    }
}
