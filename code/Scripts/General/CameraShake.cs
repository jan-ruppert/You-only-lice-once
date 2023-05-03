using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the shaking of the camera.
/// </summary>

public class CameraShake : MonoBehaviour
{
    /// <summary>
    /// While elapsed deltaTime is smaller then given duration, the camera is moved in a random direction (expense depends on given magnitude).
    /// In the end, camera is moved to starting position
    /// </summary>
    /// <param name="duration">duration of the camera shake</param>
    /// <param name="magnitude">magnitude of the camera shake</param>
    /// <returns>null</returns>
    public IEnumerator Shake (float duration, float magnitude) {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x,y,originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
