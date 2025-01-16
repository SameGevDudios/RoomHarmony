using UnityEngine;
using DG.Tweening;

public class Movable : MonoBehaviour, IMovable
{
    [Header("Fall")]
    [SerializeField] private float _fallLowestPosition = -10;
    [SerializeField] private float _fallDuration = 2;

    [Space(1)]
    [Header("Jump")]
    [SerializeField] private float _hoverHeight = 1;
    [SerializeField] private float _hoverDuration = 1;
    [SerializeField] private float _jumpDuration = 2;

    private Tween _moveTween;
    private Sequence _jumpSequence;

    private void Start()
    {
        StartFall();
    }
    public void StartFall()
    {
        _moveTween = transform.DOMoveY(_fallLowestPosition, _fallDuration).SetEase(Ease.InQuad);
    }
    public void AnimateStop()
    {
        StopFall();
        float startPosY = transform.position.y;
        _jumpSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(startPosY + _hoverHeight, _hoverDuration).SetEase(Ease.OutSine))
            .Append(transform.DOMoveY(startPosY, _jumpDuration).SetEase(Ease.OutBounce));
    }
    public  void StopFall()
    {
        _moveTween.Kill();
        _jumpSequence.Kill();
    }
    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }
    public Vector3 GetPosition() =>
        transform.position;
}
