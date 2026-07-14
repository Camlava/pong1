
using System.Collections;
using UnityEngine;

public class PaddleStats : MonoBehaviour
{
    public float moveSpeed = 8f;

    private Vector3 originalScale;

    private Coroutine longPaddleRoutine;
    private Coroutine speedRoutine;
    private Coroutine shrinkRoutine;

    void Awake()
    {
        originalScale = transform.localScale;
    }


    // LONG PADDLE
    public void StartLongPaddle(float multiplier, float duration)
    {
        if (longPaddleRoutine != null)
            StopCoroutine(longPaddleRoutine);

        longPaddleRoutine = StartCoroutine(LongPaddle(multiplier, duration));
    }

    IEnumerator LongPaddle(float multiplier, float duration)
    {
        transform.localScale = new Vector3(
            originalScale.x,
            originalScale.y * multiplier,
            originalScale.z
        );

        yield return new WaitForSeconds(duration);

        transform.localScale = originalScale;

        longPaddleRoutine = null;
    }


    // SPEED BOOST
    public void StartSpeedBoost(float multiplier, float duration)
    {
        if (speedRoutine != null)
            StopCoroutine(speedRoutine);

        speedRoutine = StartCoroutine(SpeedBoost(multiplier, duration));
    }

    IEnumerator SpeedBoost(float multiplier, float duration)
    {
        moveSpeed *= multiplier;

        yield return new WaitForSeconds(duration);

        moveSpeed /= multiplier;

        speedRoutine = null;
    }


    // SHRINK
    public void StartShrink(float factor, float duration)
    {
        if (shrinkRoutine != null)
            StopCoroutine(shrinkRoutine);

        shrinkRoutine = StartCoroutine(Shrink(factor, duration));
    }

    IEnumerator Shrink(float factor, float duration)
    {
        transform.localScale = new Vector3(
            originalScale.x,
            originalScale.y * factor,
            originalScale.z
        );

        yield return new WaitForSeconds(duration);

        transform.localScale = originalScale;

        shrinkRoutine = null;
    }
}