using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TheifMovement : MonoBehaviour
{
    public float BasicSpeed = 2.0f;
    public Collider2D HitboxCollider;

    private Rigidbody2D rigid;
    private bool first = true;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();

        //Physics.IgnoreLayerCollision(9, 8);
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(BasicSpeed * (first ? 1.0f : 3.0f), rigid.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 8 && first) {
            Debug.Log("Theif Collision Entered");
            CharacterMovement.Singleton.IsMovable = true;
            //HitboxCollider.enabled = false;
            first = false;
            StartCoroutine(StartZoomIn());
        }
    }

    IEnumerator StartZoomIn() {
        Camera.main.DOOrthoSize(0.65f, 0.2f);
        Time.timeScale = 0.05F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        yield return new WaitForSeconds(0.2f);
        Camera.main.DOOrthoSize(1.2f, 0.3f);
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F;
    }
}
