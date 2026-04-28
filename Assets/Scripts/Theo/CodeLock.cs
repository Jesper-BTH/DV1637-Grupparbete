using UnityEngine;
using UnityEngine.Events;

public class CodeLock : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Dial[] dials;

    [Header(" Settings ")]
    [SerializeField] private string combination = "12345";

    [Header(" Events ")]
    [SerializeField] private UnityEvent onCorrectCombinationFound;

    private void Start()
    {
        if (combination.Length != dials.Length)
        {
            Debug.LogError("Combination length must match number of dials!");
        }
    }

    public void CheckCombination(Dial changedDial)
    {
        for (int i = 0; i < dials.Length; i++)
        {
            int expected = combination[i] - '0';

            if (dials[i].GetNumber() != expected)
            {
                return;
            }
        }

        onCorrectCombinationFound?.Invoke();
    }
}