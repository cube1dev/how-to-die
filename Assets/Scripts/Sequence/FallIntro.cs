using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallIntro : MonoBehaviour
{
    public Rigidbody2D MainCharacterRigid;

    private bool did = false;

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8 && !did) {
            // todo: play crash sound
            //CameraShaker.Singleton.Shake(0.5f, 0.5f);
            Camera.main.DOShakeRotation(3f, strength: 2f);
            did = true;
            StartCoroutine(StartSequence(coll.gameObject));
        }
    }

    IEnumerator StartSequence(GameObject main) {
        MainCharacterRigid.velocity = Vector2.zero;
        MainCharacterRigid.gravityScale = 0f;
        yield return new WaitForSeconds(3.0f);
        MainCharacterRigid.gravityScale = 1f;
        Camera.main.GetComponent<CharacterCamera>().Target = main;
        yield return new WaitForSeconds(3.0f);
        Camera.main.GetComponent<CharacterCamera>().Target = CharacterMovement.Singleton.gameObject;
    }
}
