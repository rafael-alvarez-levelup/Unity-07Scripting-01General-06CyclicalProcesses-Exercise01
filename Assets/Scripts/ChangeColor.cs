using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class change the color of a game object through interpolation.
/// </summary>
public class ChangeColor : MonoBehaviour
{
    #region Properties

    public int Loops { get; private set; }

    #endregion

    #region Private Variables

    [SerializeField] private List<Color> values;
    [SerializeField] private float transition = 2f;

    private Renderer myRenderer;
    private Color currentValue;
    private int valueIndex;
    private float transitionStep;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        Loops = 0;
        currentValue = myRenderer.material.color;
        valueIndex = 0;
        transitionStep = 0;

        StartCoroutine(ChangeColorRoutine());
    }

    #endregion

    #region Coroutines

    private IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            if (transition > transitionStep)
            {
                transitionStep += Time.deltaTime;

                float step = transitionStep / transition;

                myRenderer.material.color = Color.Lerp(currentValue, values[valueIndex], step);
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