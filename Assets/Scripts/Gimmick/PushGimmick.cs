using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushGimmick : MonoBehaviour
{
    [System.NonSerialized] public bool NeedToPushed = false;
    public float PushForce = 2.0f;

    private bool alreadyPushed = false;
    private Rigidbody2D rigid;
    private bool timelineStopped = false;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        
        StartCoroutine(TimelineAwait());
    }

    IEnumerator TimelineAwait() {
        yield return new WaitForSeconds(17.0f);
        timelineStopped = true;
    }

    void FixedUpdate() {
        if(!timelineStopped) {
            rigid.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        // todo: play push sound
        if(coll.gameObject.layer == 11) {
            if(NeedToPushed && !alreadyPushed) {
                StartCoroutine(Triggered());
            }
        }
    }

    IEnumerator Triggered() {
        Camera.main.GetComponent<CharacterCamera>().Target = gameObject;
        rigid.velocity = new Vector2(-PushForce, rigid.velocity.y);
        rigid.gravityScale = 1.0f;
        alreadyPushed = true;
        CharacterMovement.Singleton.IsMovable = false;
        yield return new WaitForSeconds(4.5f);
        // todo: escape
        CharacterMovement.Singleton.IsMovable = true;
        Camera.main.GetComponent<CharacterCamera>().Target = CharacterMovement.Singleton.gameObject;
    }
}
