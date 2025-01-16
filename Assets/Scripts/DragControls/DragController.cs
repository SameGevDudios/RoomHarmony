using UnityEngine;

public class DragController : MonoBehaviour
{
    [SerializeField] private LayerMask _searchMask;
    private IInput _input;
    private IMover _mover;
    private IMoverValidator _moverValidator;
    private SearchCollider _searchCollider;
    private bool _dragStarted;

    private void Start()
    {
        // temporary constructor call point
        Constructor(new DesktopInput(), new Mover(), new MoverValidatorMask(_searchMask));
    }
    public void Constructor(IInput input, IMover mover, IMoverValidator moverValidator)
    {
        _input = input;
        _mover = mover;
        _moverValidator = moverValidator;
    }
    private void Update()
    {
        if (_input.CursorDown())
        {
            if (_moverValidator.MovableFound(_input.CursorWorldPosition(), out IMovable movable, out _searchCollider))
            {
                StartDragMovable(movable);
            }
        }
        else if (_input.CursorHold())
        {   
            if (_dragStarted)
            {
                _mover.Drag(_input.CursorWorldPosition());
            }
            else
            {
                // drag camera
            }
        }
        else if (_input.CursorUp())
        {
            if (_dragStarted)
            {
                StopDragMovable();
            }
        }
    }
    private void StartDragMovable(IMovable movable)
    {
        _mover.StartDrag(movable, _input.CursorWorldPosition());
        _searchCollider.AllowSearch(false);
        _dragStarted = true;
    }
    private void StopDragMovable()
    {
        _mover.StopDrag();
        _searchCollider.AllowSearch(true);
        _dragStarted = false;
    }
}
