using UnityEngine;

public abstract class SearchCollider : MonoBehaviour
{
    [SerializeField] private GameObject _movableObject;
    private IMovable _movable;
    private bool _canSearch = true;
    private void Start()
    {
        _movable = _movableObject.GetComponent<IMovable>();
        if (_movable == null)
            Debug.LogError($"IMovable couldn't be found on {_movableObject.name} GameObject");
    }
    protected void AnimateStop()
    {
        if (_canSearch)
        {
            _movable.AnimateStop();
            _canSearch = false;
        }
    }
    public void AllowSearch(bool allow)
    {
        _canSearch = allow;
    }
}
