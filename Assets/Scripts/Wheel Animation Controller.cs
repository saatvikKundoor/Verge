using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimationController : MonoBehaviour
{
    private bool isSpinning = false;

    public void StartSpin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinTheWheel());
        }
    }

    private IEnumerator SpinTheWheel()
    {
        isSpinning = true;
        
        // 1. Generate random final angle (0-360) and extra full spins
        float randomFinalAngle = Random.Range(0f, 360f);
        int fullSpins = Random.Range(5, 10);
        float totalRotation = (fullSpins * 360f) + randomFinalAngle;

        float currentRotation = transform.eulerAngles.z;
        float spinTime = 3f; // Duration of the spin
        float timer = 0f;

        // 2. Animate the rotation using an easing curve (SmoothStep)
        while (timer < spinTime)
        {
            timer += Time.deltaTime;
            float t = timer / spinTime;
            
            // Smoothly interpolate the rotation
            float angle = Mathf.Lerp(-currentRotation, currentRotation + totalRotation, Mathf.SmoothStep(0f, 1f, t));
            
            // Apply rotation to the Z-axis for 2D
            transform.eulerAngles = new Vector3(0, 0, -angle);
            yield return null;
        }

        isSpinning = false;
    }
}

