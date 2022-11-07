using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TalkDialogue : MonoBehaviour
{
    public string[] TalkStrings;
    public Text TalkText;

    void Start() {
        StartDialogue();
    }

    void StartDialogue() {
        CharacterMovement.Singleton.IsMovable = false;
        transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.3f);

        StartCoroutine(Talk());
    }

    IEnumerator Talk() {
        for(int i = 0; i < TalkStrings.Length; i++) {
            TalkText.text = "";
            TalkText.DOText(TalkStrings[i], 0.4f);
            yield return new WaitForSeconds(0.4f);
            yield return new WaitUntil(() => {
                return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return);
            });
        }
        CharacterMovement.Singleton.IsMovable = true;
        transform.DOScale(new Vector3(0.0f, 0.0f, 0.0f), 0.3f);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
