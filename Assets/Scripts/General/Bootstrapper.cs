using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Drag Controller")]
    [SerializeField] private DragController _dragController;
    [SerializeField] private LayerMask _pickableSearchMask;
    [SerializeField] private Transform _cameraObject;
    [SerializeField] private float _cameraDragSpeed,
        _cameraMinPosition, _cameraMaxPosition;

    private void Awake()
    {
        IInput input = new MobileInput();
        IMover pickableMover = new Mover();
        IMoverValidator validator = new MoverValidator();
        ICameraMover cameraMover =
            new CameraMover(_cameraObject, _cameraDragSpeed, _cameraMinPosition, _cameraMaxPosition);
        _dragController.Constructor(input, pickableMover, validator, cameraMover);
    }
}
