using UnityEngine;

public class DragController : MonoBehaviour
{
    [Header("Pickable drag")]
    [SerializeField] private LayerMask _searchMask;
    private IInput _input;
    private IMoverValidator _moverValidator;
    private SearchCollider _searchCollider;
    private IMover _mover;

    [Header("Camera drag")]
    [SerializeField] private Transform _cameraObject;
    [SerializeField] private float _cameraDragSpeed, 
        _cameraMinPosition, _cameraMaxPosition;
    private ICameraMover _cameraMover;

    private bool _dragStarted;

    private void Start()
    {
        // temporary constructor call point
        ICameraMover cameraMover = 
            new CameraMover(_cameraObject, _cameraDragSpeed, _cameraMinPosition, _cameraMaxPosition);
        Constructor(new MobileInput(), new Mover(), new MoverValidatorMask(_searchMask), cameraMover);
    }
    public void Constructor(IInput input, IMover mover, IMoverValidator moverValidator, ICameraMover cameraMover)
    {
        _input = input;
        _moverValidator = moverValidator;
        _mover = mover;
        _cameraMover = cameraMover;
    }
    private void Update()
    {
        if (_input.CursorDown())
        {
            if (_moverValidator.PickableFound(_input.CursorWorldPosition(), out IPickableMove pickable, out _searchCollider))
            {
                StartDragPickable(pickable);
            }
            else
            {
                _cameraMover.StartDrag(_input.CursorScreenPosition().x);
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
                _cameraMover.Drag(_input.CursorScreenPosition().x);
            }
        }
        else if (_input.CursorUp())
        {
            if (_dragStarted)
            {
                StopDragPickable();
            }
        }
    }
    private void StartDragPickable(IPickableMove pickable)
    {
        _mover.StartDrag(pickable, _input.CursorWorldPosition());
        _searchCollider.AllowSearch(false);
        _dragStarted = true;
    }
    private void StopDragPickable()
    {
        _mover.StopDrag();
        _searchCollider.AllowSearch(true);
        _dragStarted = false;
    }
}
