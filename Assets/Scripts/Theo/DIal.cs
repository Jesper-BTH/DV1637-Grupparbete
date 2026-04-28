using UnityEngine;
using UnityEngine.Events;

public class Dial : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float animationDuration = 0.3f;

    private bool isRotating = false;
    private int currentIndex;

    private const int maxNumbers = 5;
    private const float angleStep = 360f / maxNumbers;

    [Header(" Events ")]
    [SerializeField] private UnityEvent<Dial> onDialRotated;

    private void Start()
    {
        currentIndex = 0; // always start on 1
        transform.localRotation = Quaternion.Euler(0, -angleStep * currentIndex, 0);
    }

    public void Rotate()
    {
        if (isRotating)
            return;

        currentIndex = (currentIndex + 1) % maxNumbers;
        StartCoroutine(RotateSmoothly());
    }

    private System.Collections.IEnumerator RotateSmoothly()
    {
        isRotating = true;

        Quaternion startRot = transform.localRotation;
        Quaternion endRot = startRot * Quaternion.Euler(-angleStep, 0, 0);

        float time = 0f;

        while (time < animationDuration)
        {
            transform.localRotation = Quaternion.Slerp(startRot, endRot, time / animationDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRot;

        isRotating = false;
        onDialRotated?.Invoke(this);
    }

    public int GetNumber()
    {
        return currentIndex + 1;
    }
}