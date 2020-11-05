using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class moves a game object along a series of points.
/// </summary>
public class PointsMovement : MonoBehaviour
{
    #region Properties

    public int Loops { get; private set; }

    #endregion

    #region Private Variables

    [SerializeField] private List<Vector3> values;
    [SerializeField] private float transition = 2f;

    private Vector3 currentValue;
    private int valueIndex;
    private float transitionStep;

    #endregion

    #region Unity Methods

    private void Start()
    {
        Loops = 0;
        currentValue = transform.position;
        valueIndex = 0;
        transitionStep = 0;

        StartCoroutine(PointsMovementRoutine());
    }

    #endregion

    #region Coroutines

    private IEnumerator PointsMovementRoutine()
    {
        while (true)
        {
            if (transition > transitionStep)
            {
                transitionStep += Time.deltaTime;

                float step = transitionStep / transition;

                transform.position = Vector3.Lerp(currentValue, values[valueIndex], step);
            }
            else
            {
                transitionStep = 0;

                currentValue = values[valueIndex];

                valueIndex = (valueIndex + 1) % values.Count;

                Loops++;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    #endregion
}