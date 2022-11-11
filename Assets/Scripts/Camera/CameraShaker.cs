using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Singleton;

    void Awake() {
        Singleton = this;
    }

    public Coroutine Shake(float duration, float magnitude) {
        return StartCoroutine(shake(duration, magnitude));
    }

    private IEnumerator shake(float duration, float magnitude) {
        var originalPos = new Vector3(0, 0, 0);

        var elapsedTime = 0f;

        while(elapsedTime < duration) {
            var xOff = Random.Range(-0.5f, 0.5f) * magnitude;
            var yOff = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(xOff, yOff, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
