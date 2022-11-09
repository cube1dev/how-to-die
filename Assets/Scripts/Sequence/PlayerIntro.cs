using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerIntro : MonoBehaviour {

    [SerializeField] private CharacterCamera cam;
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private PushGimmick pushGimmick;

    void Start() {
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence() {
        yield return new WaitForSeconds(11);
        transform.DOMoveY(-8.599f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        movement.IsMovable = true;
        cam.Target = gameObject;
        pushGimmick.NeedToPushed = true;
    }
}
