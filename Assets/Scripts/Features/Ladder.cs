using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject character;
    public Vector3 Target;
    public Vector3 StartPos;
    public float Speed;

    private bool used = false;
    private bool moving = false;

    void Interact() {
        if(used)
            return;
        
        StartCoroutine(rideLadder());
    }

    void Update() {
        if(moving) {
            var rigid = character.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up, ForceMode2D.Impulse);

            if(rigid.velocity.y > Speed) {
                rigid.velocity = new Vector2(rigid.velocity.x, Speed);
            }
        }
    }

    IEnumerator rideLadder() {
        used = true;
        character.transform.position = StartPos;
        var rigid = character.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
        var movement = character.GetComponent<CharacterMovement>();
        movement.IsMovable = false;
        var spriteRenderer = character.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        moving = true;
        yield return new WaitForSeconds(3.0f);
        moving = false;
        movement.IsMovable = true;
    }
}
