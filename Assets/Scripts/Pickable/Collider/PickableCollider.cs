using UnityEngine;

public class PickableCollider : MonoBehaviour, IPickableCollider
{
    [SerializeField] private float _minScale, _maxScale;
    private float _visibleHeight;

    private void Start()
    {
        Vector3[] vertices = GetColliderVertices();
        _visibleHeight = CalculateVisibleHeight(vertices);
    }
    private float CalculateVisibleHeight(Vector3[] localVertices)
    {
        Quaternion rotation = transform.rotation;
        Vector3 scale = transform.localScale;
        float minY = float.MaxValue, maxY = float.MinValue;
        foreach (var vertex in localVertices)
        {
            Vector3 transformedVertex = rotation * Vector3.Scale(vertex, scale);
            minY = Mathf.Min(minY, transformedVertex.y);
            maxY = Mathf.Max(maxY, transformedVertex.y);
        }
        return maxY - minY;
    }
    private Vector3[] GetColliderVertices()
    {
        BoxCollider2D boxCollider = GetComponentInChildren<BoxCollider2D>();
        if (boxCollider)
        {
            Vector2 size = boxCollider.size;
            return new Vector3[]
            {
                new Vector3(-size.x / 2, -size.y / 2, 0),
                new Vector3(-size.x / 2, size.y / 2, 0),
                new Vector3(size.x / 2, size.y / 2, 0),
                new Vector3(size.x / 2, -size.y / 2, 0)
            };
        }

        PolygonCollider2D polygonCollider = GetComponentInChildren<PolygonCollider2D>();
        if (polygonCollider)
        {
            Vector2[] points = polygonCollider.points;
            Vector3[] vertices = new Vector3[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                vertices[i] = points[i];
            }
            return vertices;
        }
        return null;
    }
    public float ScaleByDistance(float distance)
    {
        return Mathf.Lerp(_maxScale, _minScale, distance / _visibleHeight);
    }
}
