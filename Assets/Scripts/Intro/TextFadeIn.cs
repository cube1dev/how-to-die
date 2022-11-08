using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextFadeIn : MonoBehaviour {
    private Text text;
    public float fadeTime = 1F;
    public float delay = 0F;

    private void Awake() {
        text = GetComponent<Text>();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn() {
        yield return new WaitForSeconds(delay);

        Color color = text.color;
        while (color.a < fadeTime) {
            color.a += Time.deltaTime;
            yield return 0;
            text.color = color;
        }
    }
}
