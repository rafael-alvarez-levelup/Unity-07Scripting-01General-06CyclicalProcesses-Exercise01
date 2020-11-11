using UnityEngine;

/// <summary>
/// This class moves a game object along a series of points.
/// </summary>
public class PointsMovement : TransitionBase<Vector3>
{
    protected override void SetInitialValue()
    {
        SetCurrentValue(transform.position);
    }

    protected override void Lerp(Vector3 current, Vector3 next, float step)
    {
        transform.position = Vector3.Lerp(current, next, step);
    }
}