using UnityEngine;

public abstract class SearchCollider : MonoBehaviour
{
    [SerializeField] private GameObject _pickableMoveObject;
    private IPickableMove _pickableMove;
    private bool _canSearch = true;

    private void Start()
    {
        if(_pickableMoveObject == null)
            Debug.LogError($"Pickable Move Object is not assigned");
        else
            _pickableMove = _pickableMoveObject.GetComponent<IPickableMove>();
        if (_pickableMove == null)
            Debug.LogError($"IPickableMove couldn't be found on {_pickableMoveObject.name} GameObject");
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
