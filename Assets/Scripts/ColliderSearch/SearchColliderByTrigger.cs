using UnityEngine;

public class SearchColliderByTrigger : SearchCollider
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimateStop();
    }
}
