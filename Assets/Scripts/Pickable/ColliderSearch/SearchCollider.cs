using UnityEngine;

public abstract class SearchCollider : MonoBehaviour
{
    [SerializeField] private GameObject _pickableObject;
    private IPickableMove _pickableMove;
    private bool _canSearch = true;

    private void Start()
    {
        if(_pickableObject == null)
            Debug.LogError($"Pickable Object is not assigned");
        else
            _pickableMove = _pickableObject.GetComponent<IPickableMove>();
        if (_pickableMove == null)
            Debug.LogError($"IPickableMove couldn't be found on {_pickableObject.name} GameObject");
    }
    protected void AnimateStop()
    {
        if (_canSearch)
        {
            _pickableMove.AnimateStop();
            _canSearch = false;
        }
    }
    public void AllowSearch(bool allow)
    {
        _canSearch = allow;
    }
}
