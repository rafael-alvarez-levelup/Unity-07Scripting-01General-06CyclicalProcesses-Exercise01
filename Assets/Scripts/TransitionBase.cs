using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic base class for transition through interpolation.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class TransitionBase<T> : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private List<T> values;
    [SerializeField] private float transition = 2f;

    private T currentValue;
    private int valueIndex;

    #endregion

    #region Unity Methods

    protected virtual void Start()
    {
        SetInitialValue();

        valueIndex = 0;

        StartCoroutine(TransitionRoutine());
    }

    #endregion

    #region Coroutine

    protected IEnumerator TransitionRoutine()
    {
        float transitionStep = 0;

        while (transition > transitionStep)
        {
            transitionStep += Time.deltaTime;
            float step = transitionStep / transition;

            Lerp(currentValue, values[valueIndex], step);

            yield return null;
        }

        currentValue = values[valueIndex];
        valueIndex = (valueIndex + 1) % values.Count;

        StartCoroutine(TransitionRoutine());
    }

    #endregion

    #region My Methods

    protected abstract void SetInitialValue();

    protected abstract void Lerp(T current, T next, float step);

    protected void SetCurrentValue(T currentValue)
    {
        this.currentValue = currentValue;
    }

    #endregion
}