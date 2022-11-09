using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TalkDialogue : MonoBehaviour
{
    public string[] TalkStrings;
    public Sprite[] TalkSpritePalette;
    public int[] TalkSprites;
    public Sprite FallbackSprite;
    public Text TalkText;
    public Image TalkImage;

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
            if(TalkSprites.Length > 0) {
                var idx = TalkSprites[i];
                TalkImage.sprite = idx < 0 || idx >= TalkSprites.Length || TalkSpritePalette[idx] == null ? FallbackSprite : TalkSpritePalette[idx];
            }
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
