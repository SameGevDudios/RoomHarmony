using UnityEngine;

public interface IPickableMove
{
    void StartFall();
    void AnimateStop();
    void StopFall();
    void MoveTo(Vector3 position);
    Vector3 GetPosition();
}
