using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMovePosition : MonoBehaviour
{

    [SerializeField]
    float duration = 1;

    [Space(10)]
    [Header("Scale")]
    [SerializeField]
    AnimationCurve scaleCurve;
    [Space(10)]
    [Header("Position")]
    [SerializeField]
    AnimationCurve posCurve;

    Vector3 startPos;
    Vector3 startScale;
    Vector3 endScale;
    Vector3 endPos;
    bool animCompleated = false;

	void Awake ()
    {
        InitializeVariables();
    }
	
	void InitializeVariables()
    {
        startPos = Vector3.zero;
        startScale = Vector3.zero;
        endScale = transform.localScale;
        Debug.Log(endScale);
        Debug.Log(transform.localScale);
    }

    public void TriggerAnimation(Vector3 _endPos = default(Vector3))
    {
        if (animCompleated)
        {
            StartCoroutine(MoveFromToPosition(endPos, startPos, endScale, startScale, duration));
            animCompleated = false;
        }
        else
        {
            endPos = _endPos;
            StartCoroutine(MoveFromToPosition(startPos, endPos, startScale, endScale, duration));
            animCompleated = true;
        }
    }

    IEnumerator MoveFromToPosition(Vector3 startPos,Vector3 endPos,Vector3 startScale, Vector3 endScale,float duration)
    {
        transform.localPosition = startPos;
        transform.localScale = startScale;
        float time = 0;
        float perc = 0;
        do
        {
            time += Time.unscaledDeltaTime;
            perc = Mathf.Clamp01(time / duration);
            Vector3 tempPos = Vector3.LerpUnclamped(startPos, endPos, posCurve.Evaluate(perc));
            Vector3 tempScale = Vector3.LerpUnclamped(startScale, endScale, scaleCurve.Evaluate(perc));

            transform.localPosition = tempPos;
            transform.localScale = tempScale;
            yield return null;

        } while (perc < 1);
    }
}
