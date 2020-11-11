using UnityEngine;

/// <summary>
/// This class change the color of a game object through interpolation.
/// </summary>
public class ChangeColor : TransitionBase<Color>
{
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    protected override void SetInitialValue()
    {
        SetCurrentValue(myRenderer.material.color);
    }

    protected override void Lerp(Color current, Color next, float step)
    {
        myRenderer.material.color = Color.Lerp(current, next, step);
    }
}