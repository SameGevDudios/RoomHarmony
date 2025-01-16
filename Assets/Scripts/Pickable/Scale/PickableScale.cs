using UnityEngine;

public class PickableScale : MonoBehaviour, IPickableScale
{
    [SerializeField] private float _scaleSpeed;
    private float _currentScale = 1;
    private void Update()
    {
        UpdateScale();
    }
    private void UpdateScale()
    {
        float scale = transform.localScale.x;
        scale = Mathf.Lerp(scale, _currentScale, _scaleSpeed * Time.deltaTime);
        transform.localScale = Vector3.one * scale;
    }
    public void SetNewScale(float newScale)
    {
        _currentScale = newScale;
    }
}
