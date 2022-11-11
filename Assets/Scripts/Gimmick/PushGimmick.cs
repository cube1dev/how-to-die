using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PushGimmick : MonoBehaviour
{
    public static PushGimmick Singleton;

    [System.NonSerialized] public bool NeedToPushed = false;
    public float PushForce = 2.0f;
    public float RunSpeed = 2.0f;

    private float runSpeed;
    private bool alreadyPushed = false;
    private Rigidbody2D rigid;
    private bool timelineStopped = false;
    private bool runStarted = false;

    void Awake() {
        Singleton = this;
        rigid = GetComponent<Rigidbody2D>();
        runSpeed = RunSpeed;
        
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

        if(runStarted) {
            rigid.velocity = new Vector2(-runSpeed, rigid.velocity.y);
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

    public void OnPlayerDetected() {
        StartCoroutine(StartRun());
    }

    IEnumerator StartRun() {
        Camera.main.DOOrthoSize(1.5f, 0.2f);
        runStarted = true;
        runSpeed *= 1.5f;

        yield return null;
    }

    IEnumerator Triggered() {
        rigid.velocity = new Vector2(-PushForce, rigid.velocity.y);
        rigid.gravityScale = 1.0f;
        alreadyPushed = true;
        CharacterMovement.Singleton.IsMovable = false;
        yield return new WaitForSeconds(3.0f); // FallIntro (Gravity Stop Wait)
        yield return new WaitForSeconds(3.0f);
        // todo: escape
        CharacterMovement.Singleton.IsMovable = true;
        runStarted = true;
        /*
        yield return new WaitForSeconds(7.0f);
        runStarted = false;
        */
    }
}
